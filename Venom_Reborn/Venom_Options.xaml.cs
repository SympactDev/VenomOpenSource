using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Venom_Settings;
namespace Venom_Options
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AlwaysOnTop.IsChecked = Venom_Settings.Settings.Instance.TopMost;
            AutoLaunch.IsChecked = Venom_Settings.Settings.Instance.AutoLaunch;
            FPS_Booster.IsChecked = Venom_Settings.Settings.Instance.FPSBooster;
            AutoAttach.IsChecked = Venom_Settings.Settings.Instance.AutoAttach;
            base.Topmost = Venom_Settings.Settings.Instance.TopMost;
        }

        private void Venom_Options_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (KillRBLX.IsChecked == true)
            {
                foreach (Process robloxprocess in Process.GetProcessesByName("RobloxPlayerBeta"))
                    robloxprocess.Kill();
            }
            else
            {

            }
        }

        private void AutoAttach_Checked(object sender, RoutedEventArgs e)
        {
            if (AutoAttach.IsChecked == true)
            {
                Settings.Instance.AutoAttach = true;
            }
            else
            {
                Settings.Instance.AutoAttach = false;
            }
        }

        private void Venom_Options_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Instance.TopMost = AlwaysOnTop.IsChecked.GetValueOrDefault();
            Settings.Instance.AutoLaunch = AutoLaunch.IsChecked.GetValueOrDefault();

            Settings.Instance.FPSBooster = FPS_Booster.IsChecked.GetValueOrDefault();

            Settings.Instance.AutoAttach = AutoAttach.IsChecked.GetValueOrDefault();

            Settings.Instance.Apply();
        }

        private void AlwaysOnTop_Checked(object sender, RoutedEventArgs e)
        {
            if (AlwaysOnTop.IsChecked == true)
            {
                base.Topmost = Venom_Settings.Settings.Instance.TopMost;
                Venom_Settings.Settings.Instance.Apply();
            }
            else
            {
                base.Topmost = Venom_Settings.Settings.Instance.TopMost;
                Venom_Settings.Settings.Instance.Apply();
            }
        }

        private void FPS_Booster_Checked(object sender, RoutedEventArgs e)
        {
            if (FPS_Booster.IsChecked == true)
            {
                Settings.Instance.FPSBooster = true;
            }
            else
            {
                Settings.Instance.FPSBooster = false;
            }
        }

        private void AutoLaunch_Checked(object sender, RoutedEventArgs e)
        {
            if (AutoLaunch.IsChecked == true)
            {
                Settings.Instance.AutoLaunch = true;
            }
            else
            {
                Settings.Instance.AutoLaunch = false;
            }
        }
    }
}
