using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Venom_Loader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
            DoubleAnimation da2 = new DoubleAnimation();
            this.ProgressBox.BeginAnimation(UIElement.OpacityProperty, da2);
            da2.Duration = TimeSpan.FromSeconds(1.0);
            da2.From = new double?((double)1);
            da2.To = new double?(0.0);
            load();
        }


        private async void load ()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = TimeSpan.FromSeconds(1.0);
            da.From = new double?(0.0);
            da.To = new double?((double)1);
            
            this.ProgressBox.BeginAnimation(UIElement.OpacityProperty, da);
            await Task.Delay(8000);
            ProgressBox.Value = 10;
            if (ProgressBox.Value == 10)
            {
                Status.Content = "Loading...";
            }
            await Task.Delay(2000);
            ProgressBox.Value = 20;
            if (ProgressBox.Value == 20)
            {
                Status.Content = "Validating...";
            }
            await Task.Delay(4000);
            ProgressBox.Value = 30;
            if (ProgressBox.Value == 30)
            {
                WebClient client = new WebClient();
                client.DownloadFile("https://github.com/Sprite2033/VenomDLL/raw/master/Venom.dll", "Venom.dll");
                Status.Content = "Downloading Data...";
            }
            await Task.Delay(3929);
            ProgressBox.Value = 40;
            if (ProgressBox.Value == 40)
            {
                Status.Content = "Connecting...";
            }
            await Task.Delay(2000);

            ProgressBox.Value = 100;
            if (ProgressBox.Value == 100)
            {
                Status.Content = "Ready!";

               
            }
            await Task.Delay(1000);
            DoubleAnimation da2 = new DoubleAnimation();
            da2.Duration = TimeSpan.FromSeconds(1.0);
            da2.From = new double?((double)1);
            da2.To = new double?(0.0);
            this.ProgressBox.BeginAnimation(UIElement.OpacityProperty, da2);

            await Task.Delay(600);
            Ino();

        }

        private void Ino()
        {
            Venom_Reborn.MainWindow window = new Venom_Reborn.MainWindow();
            window.Show();
            base.Hide();
        }
        private async void Timer_Tick(object sender, EventArgs e)
        {
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ProgressBox_ValueChanged()
        {

        }
    }
}
