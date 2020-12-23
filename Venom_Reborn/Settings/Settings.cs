using System;
using Microsoft.Win32;

namespace Venom_Settings
{
	// Token: 0x02000036 RID: 54
	internal class Settings
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000151 RID: 337 RVA: 0x00006D24 File Offset: 0x00004F24
		public static Settings Instance
		{
			get
			{
				Settings result;
				bool flag = (result = Settings.instance) == null;
				if (flag)
				{
					result = (Settings.instance = new Settings());
				}
				return result;
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00006D54 File Offset: 0x00004F54
		public Settings()
		{
			this.registryKey = Registry.CurrentUser.OpenSubKey("Software\\VenomReborn", true);
			bool flag = this.registryKey == null;
			if (flag)
			{
				this.registryKey = Registry.CurrentUser.CreateSubKey("Software\\VenomReborn");
			}
		}


		public string VenomDirectory
		{
			get
			{
				return Convert.ToString(this.registryKey.GetValue("VenomDirectory"));
			}
			set
			{
				this.registryKey.SetValue("VenomDirectory", value);
			}
		}



		public string EditorContent
		{
			get
			{
				return Convert.ToString(this.registryKey.GetValue("EditorContent"));
			}
			set
			{
				this.registryKey.SetValue("EditorContent", value);
			}
		}


		// Token: 0x06000153 RID: 339 RVA: 0x00006DA3 File Offset: 0x00004FA3
		public void Apply()
		{
			Venom_Reborn.MainWindow.Instance.Topmost = this.TopMost;
			Settings.Instance.TopMost = this.TopMost;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000154 RID: 340 RVA: 0x00006DC8 File Offset: 0x00004FC8
		// (set) Token: 0x06000155 RID: 341 RVA: 0x00006DEF File Offset: 0x00004FEF
		public bool AutoLaunch
		{
			get
			{
				return Convert.ToBoolean(this.registryKey.GetValue("AutoLaunch"));
			}
			set
			{
				this.registryKey.SetValue("AutoLaunch", value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006E0C File Offset: 0x0000500C
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00006E33 File Offset: 0x00005033

		public bool FPSBooster
		{
			get
			{
				return Convert.ToBoolean(this.registryKey.GetValue("FPSBooster"));
			}
			set
			{
				this.registryKey.SetValue("FPSBooster", value);
			}
		}

		public bool SaveLogin
		{
			get
			{
				return Convert.ToBoolean(this.registryKey.GetValue("SaveLogin"));
			}
			set
			{
				this.registryKey.SetValue("SaveLogin", value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006E0C File Offset: 0x0000500C
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00006E33 File Offset: 0x00005033

		public bool AutoAttach
		{
			get
			{
				return Convert.ToBoolean(this.registryKey.GetValue("AutoAttach"));
			}
			set
			{
				this.registryKey.SetValue("AutoAttach", value);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00006E50 File Offset: 0x00005050
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00006E77 File Offset: 0x00005077
		public bool TopMost
		{
			get
			{
				return Convert.ToBoolean(this.registryKey.GetValue("TopMost"));
			}
			set
			{
				this.registryKey.SetValue("TopMost", value);
			}
		}

		// Token: 0x040000BF RID: 191
		private static Settings instance;

		// Token: 0x040000C0 RID: 192
		private bool GetValueOrDefault;

		// Token: 0x040000C1 RID: 193
		private RegistryKey registryKey;
	}
}
