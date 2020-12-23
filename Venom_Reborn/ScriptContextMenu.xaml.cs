using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Venom_Injection;
using Venom_Settings;

namespace DiscordX
{
	// Token: 0x02000002 RID: 2
	public partial class ScriptContextMenu : Window
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ScriptContextMenu()
		{
			this.InitializeComponent();
			base.Topmost = Settings.Instance.TopMost;
			base.Deactivated += delegate(object sender, EventArgs e)
			{
				base.Hide();
			};
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002085 File Offset: 0x00000285
		public void Show(string filePath)
		{
			this.FilePath = filePath;
			base.Show();
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002098 File Offset: 0x00000298
		private void Execute_Click(object sender, RoutedEventArgs e)
		{
			if (VenomInteract.NamedPipeExist(VenomInteract.luapipename))
            {
				VenomInteract.Execute(File.ReadAllText(this.FilePath));
				base.Hide();
			}
			
			base.Hide();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020CE File Offset: 0x000002CE
		private void Load_Click(object sender, RoutedEventArgs e)
		{
			Venom_Reborn.MainWindow.Instance.SetEditorText(File.ReadAllText(this.FilePath));
			base.Hide();
		}

		// Token: 0x04000001 RID: 1
		private string FilePath;
	}
}
