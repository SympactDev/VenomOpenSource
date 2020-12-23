using System;
using System.Collections.Generic;
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
using Venom_Injection;

namespace Venom_Hub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Venom_Hub_MouseDown(object sender, MouseButtonEventArgs e)
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
            VenomInteract.Execute("loadstring(game:HttpGet('https://raw.githubusercontent.com/HazeWasTaken/Mist/master/Mist%20Main', true))()");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute("loadstring(game:HttpGet('https://system-exodus.com/scripts/madlads/MadLadsAR.lua',true))()");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/x24KgNwj'))()");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/0uBnJZeW'))()");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute("loadstring(game:HttpGet('https://pastebin.com/raw/vhQpciap'))()");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute("loadstring(game:GetObjects('rbxassetid://418957341')[1].Source)()");
        }
    }
}
