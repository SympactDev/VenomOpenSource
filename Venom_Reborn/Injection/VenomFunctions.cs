using System;
using System.Reflection;
using Venom_Reborn;

namespace Venom_Injection
{
	// Token: 0x0200002D RID: 45
	
	internal class Venom
	{
		
		// Token: 0x06000124 RID: 292 RVA: 0x0000D55C File Offset: 0x0000B75C
		public static void Attach()
		{
			switch (Injector.DllInjector.GetInstance.Inject("RobloxPlayerBeta", AppDomain.CurrentDomain.BaseDirectory + Venom.dll))
			{
			}
		}

		// Token: 0x040000E7 RID: 231
		public static string dll = "Venom.dll";// Venom's Dll Name
	}
}
