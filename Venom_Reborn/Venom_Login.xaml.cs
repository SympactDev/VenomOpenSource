using Auth.GG_Winform_Example;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Venom_Settings;

namespace Venom_Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Directory.CreateDirectory("Auth");
            
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            SaveLoginInfo();
            OnProgramStart.Initialize("Venom", "59771", "c48AG6HORSlQZMCkrjZnwB0qjK1j8m10bhw", "1.0");
        }


        public void SaveLoginInfo()
        {
            if (Settings.Instance.SaveLogin == true)
            {
                Venom_Loader.MainWindow mainWindow = new Venom_Loader.MainWindow();
                mainWindow.Show();
                base.Hide();
            }
            else
            {
                Venom_Login.Show();

            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Settings.Instance.SaveLogin == true)
            {
                Venom_Loader.MainWindow mainWindow = new Venom_Loader.MainWindow();
                mainWindow.Show();
                base.Hide();
            }
            else
            {
                Venom_Login.Show();

            }
        }

        private void Venom_Login_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (API.Login(username.Text, password.Text))
            {
                //Put code here of what you want to do after successful login
                System.Windows.MessageBox.Show("Login successful!", "Success", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Information);
                Venom_Loader.MainWindow mainWindow = new Venom_Loader.MainWindow();
                mainWindow.Show();
                Settings.Instance.SaveLogin = true;
                base.Hide();

            }
        }

        private void Venom_Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Venom_Reborn.Properties.Settings.Default.SaveLogin = username.Text;

            Venom_Reborn.Properties.Settings.Default.SaveLogin = password.Text;

            Venom_Reborn.Properties.Settings.Default.Save();

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void login_Copy_Click(object sender, RoutedEventArgs e)
        {
            Venom_Register.MainWindow mainWindow = new Venom_Register.MainWindow();
            mainWindow.Show();
            base.Hide();
        }
    }
}
