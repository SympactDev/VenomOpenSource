using DiscordX;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Venom_Injection;
using Venom_Settings;
using VisioForge.Shared.MediaFoundation.OPM;

namespace Venom_Reborn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ProgressBox.Visibility = Visibility.Hidden;
            Status.Visibility = Visibility.Hidden;
            this.ScriptContext = new ScriptContextMenu();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1.0);
            doubleAnimation.From = new double?(0.0);
            doubleAnimation.To = new double?((double)1);
            this.Venom_Reborn.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
            this.ScriptWatcher = new FileSystemWatcher(System.IO.Path.Combine(Settings.Instance.VenomDirectory, "scripts"));
            this.ScriptWatcher.Created += delegate (object sender, FileSystemEventArgs e)
            {
                base.Dispatcher.Invoke(new Action(this.LoadScripts));
            };
            this.ScriptWatcher.Renamed += delegate (object sender, RenamedEventArgs e)
            {
                base.Dispatcher.Invoke(new Action(this.LoadScripts));
            };
            this.ScriptWatcher.Deleted += delegate (object sender, FileSystemEventArgs e)
            {
                base.Dispatcher.Invoke(new Action(this.LoadScripts));
            };

            this.ScriptWatcher.EnableRaisingEvents = true;

            this.LoadScripts();

            MainWindow.Instance = this;
            base.Topmost = Settings.Instance.TopMost;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(0);
            timer.Start();
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += Timer2_Tick;

            timer2.Start();

            this.TextEditor1.Text = "";
            this.TextEditor1.ShowLineNumbers = true;
            this.TextEditor1.FontFamily = new global::System.Windows.Media.FontFamily("Consolas");
            this.TextEditor1.FontSize = 14.0;
            this.TextEditor1.HorizontalScrollBarVisibility = global::System.Windows.Controls.ScrollBarVisibility.Auto;
            this.TextEditor1.VerticalScrollBarVisibility = global::System.Windows.Controls.ScrollBarVisibility.Auto;
            base.Margin = new global::System.Windows.Thickness(0.0, 0.0, 2.0, 2.0);
            this.TextEditor1.LineNumbersForeground = global::System.Windows.Media.Brushes.Gray;
            this.TextEditor1.Options.AllowScrollBelowDocument = true;
            global::System.Windows.Shapes.Line line = new global::System.Windows.Shapes.Line
            {
                X1 = 0.0,
                Y1 = 0.0,
                X2 = 0.0,
                Y2 = 1.0,
                Stretch = global::System.Windows.Media.Stretch.Fill,
                StrokeThickness = 1.0,
                Margin = new global::System.Windows.Thickness(2.0, 0.0, 6.0, 0.0),
                Tag = new object()
            };
            line.SetBinding(global::System.Windows.Shapes.Shape.StrokeProperty, new global::System.Windows.Data.Binding("LineNumbersForeground")
            {
                Source = this.TextEditor1
            });
            this.TextEditor1.TextArea.LeftMargins.RemoveAt(1);
            this.TextEditor1.TextArea.LeftMargins.Insert(1, line);
            using (global::System.IO.Stream stream = global::System.IO.File.OpenRead(global::System.IO.Directory.GetCurrentDirectory() + "\\SharpLua-Mode.xshd"))
            {
                using (global::System.Xml.XmlTextReader xmlTextReader = new global::System.Xml.XmlTextReader(stream))
                {
                    this.TextEditor1.SyntaxHighlighting = global::ICSharpCode.AvalonEdit.Highlighting.Xshd.HighlightingLoader.Load(xmlTextReader, global::ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance);
                }
            }




        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length == 0;
            bool flag2 = flag;
            if (flag2)
            {

                ProgressBox.Visibility = Visibility.Hidden;
                Status.Visibility = Visibility.Hidden;
                MainWindow.Connected = false;
            }
            else
            {

            }
        }

        private void LoadScripts()
        {
            StackPanel stackPanel = new StackPanel();
            using (IEnumerator<string> enumerator = Directory.EnumerateFiles(System.IO.Path.Combine(Settings.Instance.VenomDirectory, "scripts")).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    string currentFile = enumerator.Current;
                    string extension = System.IO.Path.GetExtension(currentFile);
                    bool flag = extension == ".lua" || extension == ".txt";
                    if (flag)
                    {
                        System.Windows.Controls.Button button = new System.Windows.Controls.Button
                        {
                            Content = System.IO.Path.GetFileName(currentFile),
                            Height = 22.0,
                            Margin = new Thickness(0.0, 0.0, 0.0, 5.0),
                            Style = (System.Windows.Application.Current.FindResource("RoundButton") as Style)
                        };
                        button.MouseRightButtonUp += delegate (object _, MouseButtonEventArgs args)
                        {
                            this.ShowScriptContextMenu(args, currentFile);
                        };
                        button.MouseLeftButtonUp += delegate (object _, MouseButtonEventArgs args)
                        {
                            this.ShowScriptContextMenu(args, currentFile);
                        };
                        stackPanel.Children.Add(button);
                    }
                }
            }
            this.ScriptList.Content = stackPanel;
        }


        public FileSystemWatcher ScriptWatcher;


        public void SetEditorText(string text)
        {
            this.TextEditor1.Text = text;
        }

        private void ShowScriptContextMenu(MouseButtonEventArgs args, string file)
        {
            Point position = args.GetPosition(null);
            this.ScriptContext.Left = position.X - 10.0 + base.Left;
            this.ScriptContext.Top = position.Y - 10.0 + base.Top;
            this.ScriptContext.Owner = this;
            this.ScriptContext.Show(file);
        }

        private readonly ScriptContextMenu ScriptContext;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.Instance.FPSBooster == true)
            {
                VenomInteract.Execute("loadstring(game:HttpGet('https://paste.sh/YhcljwI4#YBIH-RdFwXhaUN3GPK-tEkSD'))()");
            }
            else
            {

            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (Venom_Settings.Settings.Instance.AutoAttach == true)
            {
                bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length == 0;
                bool flag2 = flag;
                if (flag2)
                {


                }
                else
                {
                    bool Connecting = MainWindow.Connecting;
                    if (!Connecting)
                    {
                        bool Connected = MainWindow.Connected;
                        if (Connected)
                        {





                        }
                        else
                        {
                            MainWindow.Connecting = true;
                            ProgressBox.Visibility = Visibility.Visible;

                            DoubleAnimation da = new DoubleAnimation();
                            da.Duration = TimeSpan.FromSeconds(1.0);


                            this.ProgressBox.BeginAnimation(UIElement.OpacityProperty, da);
                            await Task.Delay(2000);

                            ProgressBox.Value = 10;
                            await Task.Delay(2000);
                            ProgressBox.Value = 20;
                            await Task.Delay(1000);
                            ProgressBox.Value = 30;
                            await Task.Delay(1000);
                            ProgressBox.Value = 40;
                            await Task.Delay(3000);
                            ProgressBox.Value = 50;
                            await Task.Delay(2000);

                            da.From = new double?(0.0);

                            da.To = new double?((double)1);

                            ProgressBox.Value = 100;
                            if (ProgressBox.Value == 100)
                            {
                                Venom.Attach();
                                await Task.Delay(1000);


                                await Task.Delay(1000);
                                DoubleAnimation animation = new DoubleAnimation();
                                animation.To = new double?((double)1);
                                this.Status.BeginAnimation(UIElement.OpacityProperty, da);

                                Status.Visibility = Visibility.Visible;
                                await Task.Delay(2000);
                                DoubleAnimation doubleAnimation1 = new DoubleAnimation();
                                doubleAnimation1.Duration = TimeSpan.FromSeconds(3.0);
                                doubleAnimation1.From = new double?(0.0);
                                await Task.Delay(2000);
                                doubleAnimation1.To = new double?((double)0);
                                Status.BeginAnimation(UIElement.OpacityProperty, doubleAnimation1);
                                await Task.Delay(1);
                                drag.Visibility = Visibility.Visible;

                                Status.Visibility = Visibility.Hidden;
                                ProgressBox.Visibility = Visibility.Hidden;
                                MainWindow.Connected = true;
                                MainWindow.Connecting = false;
                            }



                        }
                    







                }
                    else
                    {

                    }
                }
            }
        }

        private void Venom_Reborn_MouseDown(object sender)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextEditor1.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            VenomInteract.Execute(TextEditor1.Text);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();

            openFile.Title = "Venom - OpenFile";

            openFile.Filter = "Text files (*.txt)|*.txt|Lua files (*.Lua*)|*.*";

            if (openFile.ShowDialog() == true)
            {
                TextEditor1.Text = File.ReadAllText(openFile.FileName);
            }

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Lua files (*.Lua*)|*.*";

            saveFileDialog.Title = "Venom - SaveFile";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextEditor1.Text);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();

            openFile.Title = "Venom - Execute File";

            openFile.Filter = "Text files (*.txt)|*.txt|Lua files (*.Lua*)|*.*";

            if (openFile.ShowDialog() == true)
            {
                VenomInteract.Execute(File.ReadAllText(openFile.FileName));
            }
        }

        public static MainWindow Instance;

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Venom_Options.MainWindow options = new Venom_Options.MainWindow();
            options.Show();

        }

        private void ScriptList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Venom_Hub.MainWindow window = new Venom_Hub.MainWindow();
            window.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Venom_Reborn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Venom_Reborn_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Drag_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public static bool Connecting;
        public static bool Connected;
        private async void Button_Click_9(object sender, RoutedEventArgs e)
        {
            bool flag = Process.GetProcessesByName("RobloxPlayerBeta").Length == 0;
            bool flag2 = flag;
            if (flag2)
            {


            }
            else
            {
                bool Connecting = MainWindow.Connecting;
                if (!Connecting)
                {
                    bool Connected = MainWindow.Connected;
                    if (Connected)
                    {

                        



                    }
                    else
                    {
                        MainWindow.Connecting = true;
                        ProgressBox.Visibility = Visibility.Visible;
                        
                        DoubleAnimation da = new DoubleAnimation();
                        da.Duration = TimeSpan.FromSeconds(1.0);
                       

                        this.ProgressBox.BeginAnimation(UIElement.OpacityProperty, da);
                        await Task.Delay(1000);
                        
                        ProgressBox.Value = 10;
                        await Task.Delay(1000);
                        ProgressBox.Value = 20;
                        await Task.Delay(1000);
                        ProgressBox.Value = 30;
                        await Task.Delay(1000);
                        ProgressBox.Value = 40;
                        await Task.Delay(2000);
                        ProgressBox.Value = 50;
                        await Task.Delay(1000);
                        
                        da.From = new double?(0.0);
                        
                        da.To = new double?((double)1);
                        
                        ProgressBox.Value = 100;
                        if (ProgressBox.Value == 100)
                        {
                            Venom.Attach();
                            await Task.Delay(1000);
                           
                            
                            await Task.Delay(1000);
                            DoubleAnimation animation = new DoubleAnimation();
                            animation.To = new double?((double)1);
                            this.Status.BeginAnimation(UIElement.OpacityProperty, da);

                            Status.Visibility = Visibility.Visible;
                            await Task.Delay(2000);
                            DoubleAnimation doubleAnimation1 = new DoubleAnimation();
                            doubleAnimation1.Duration = TimeSpan.FromSeconds(3.0);
                            doubleAnimation1.From = new double?(0.0);
                            await Task.Delay(2000);
                            doubleAnimation1.To = new double?((double)0);
                            Status.BeginAnimation(UIElement.OpacityProperty, doubleAnimation1);
                            await Task.Delay(1);
                            drag.Visibility = Visibility.Visible;
                           
                            Status.Visibility = Visibility.Hidden;
                            ProgressBox.Visibility = Visibility.Hidden;
                            MainWindow.Connected = true;
                            MainWindow.Connecting = false;
                        }

                        

                    }
                }
            }
        }
    }
}
