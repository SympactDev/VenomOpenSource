using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Venom_Reborn
{
	// Token: 0x02000013 RID: 19
	internal class Injector
	{
		// Token: 0x02000014 RID: 20
		public enum DllInjectionResult
		{
			// Token: 0x0400007C RID: 124
			DllNotFound,
			// Token: 0x0400007D RID: 125
			GameProcessNotFound,
			// Token: 0x0400007E RID: 126
			InjectionFailed,
			// Token: 0x0400007F RID: 127
			Success
		}

		// Token: 0x02000015 RID: 21
		public sealed class DllInjector
		{
			// Token: 0x06000076 RID: 118
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000077 RID: 119
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int CloseHandle(IntPtr hObject);

			// Token: 0x06000078 RID: 120
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

			// Token: 0x06000079 RID: 121
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GetModuleHandle(string lpModuleName);

			// Token: 0x0600007A RID: 122
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x0600007B RID: 123
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

			// Token: 0x0600007C RID: 124
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600007D RID: 125 RVA: 0x000082C0 File Offset: 0x000064C0
			public static Injector.DllInjector GetInstance
			{
				get
				{
					bool flag = Injector.DllInjector._instance == null;
					bool flag2 = flag;
					if (flag2)
					{
						Injector.DllInjector._instance = new Injector.DllInjector();
					}
					return Injector.DllInjector._instance;
				}
			}

			// Token: 0x0600007E RID: 126 RVA: 0x00002059 File Offset: 0x00000259
			private DllInjector()
			{
			}

			// Token: 0x0600007F RID: 127 RVA: 0x000082F4 File Offset: 0x000064F4
			public Injector.DllInjectionResult Inject(string sProcName, string sDllPath)
			{
				bool flag = !File.Exists(sDllPath);
				bool flag2 = flag;
				Injector.DllInjectionResult result;
				if (flag2)
				{
					result = Injector.DllInjectionResult.DllNotFound;
				}
				else
				{
					uint num = 0U;
					Process[] processes = Process.GetProcesses();
					for (int i = 0; i < processes.Length; i++)
					{
						bool flag3 = processes[i].ProcessName == sProcName;
						bool flag4 = flag3;
						if (flag4)
						{
							num = (uint)processes[i].Id;
							break;
						}
					}
					bool flag5 = num == 0U;
					bool flag6 = flag5;
					if (flag6)
					{
						result = Injector.DllInjectionResult.GameProcessNotFound;
					}
					else
					{
						bool flag7 = !this.bInject(num, sDllPath);
						bool flag8 = flag7;
						if (flag8)
						{
							result = Injector.DllInjectionResult.InjectionFailed;
						}
						else
						{
							result = Injector.DllInjectionResult.Success;
						}
					}
				}
				return result;
			}

			// Token: 0x06000080 RID: 128 RVA: 0x000083A4 File Offset: 0x000065A4
			private bool bInject(uint pToBeInjected, string sDllPath)
			{
				IntPtr intPtr = Injector.DllInjector.OpenProcess(1082U, 1, pToBeInjected);
				bool flag = intPtr == Injector.DllInjector.INTPTR_ZERO;
				bool flag2 = flag;
				bool result;
				if (flag2)
				{
					result = false;
				}
				else
				{
					IntPtr procAddress = Injector.DllInjector.GetProcAddress(Injector.DllInjector.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
					bool flag3 = procAddress == Injector.DllInjector.INTPTR_ZERO;
					bool flag4 = flag3;
					if (flag4)
					{
						result = false;
					}
					else
					{
						IntPtr intPtr2 = Injector.DllInjector.VirtualAllocEx(intPtr, (IntPtr)null, (IntPtr)sDllPath.Length, 12288U, 64U);
						bool flag5 = intPtr2 == Injector.DllInjector.INTPTR_ZERO;
						bool flag6 = flag5;
						if (flag6)
						{
							result = false;
						}
						else
						{
							byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);
							bool flag7 = Injector.DllInjector.WriteProcessMemory(intPtr, intPtr2, bytes, (uint)bytes.Length, 0) == 0;
							bool flag8 = flag7;
							if (flag8)
							{
								result = false;
							}
							else
							{
								bool flag9 = Injector.DllInjector.CreateRemoteThread(intPtr, (IntPtr)null, Injector.DllInjector.INTPTR_ZERO, procAddress, intPtr2, 0U, (IntPtr)null) == Injector.DllInjector.INTPTR_ZERO;
								bool flag10 = flag9;
								if (flag10)
								{
									result = false;
								}
								else
								{
									Injector.DllInjector.CloseHandle(intPtr);
									result = true;
								}
							}
						}
					}
				}
				return result;
			}

			// Token: 0x04000080 RID: 128
			private static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

			// Token: 0x04000081 RID: 129
			private static Injector.DllInjector _instance;
		}
	}
}
