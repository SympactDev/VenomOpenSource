﻿#pragma checksum "..\..\Venom_Options.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B7699A92CC1A7CFA9766E8567877E07D0B0188392E84D71E746C1DC9AB8A6B75"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Venom_Options;


namespace Venom_Options {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Venom_Options.MainWindow Venom_Options;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoAttach;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox FPS_Booster;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AutoLaunch;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AlwaysOnTop;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Venom_Options.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox KillRBLX;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Venom;component/venom_options.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Venom_Options.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Venom_Options = ((Venom_Options.MainWindow)(target));
            
            #line 8 "..\..\Venom_Options.xaml"
            this.Venom_Options.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Venom_Options_MouseDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Venom_Options.xaml"
            this.Venom_Options.Closing += new System.ComponentModel.CancelEventHandler(this.Venom_Options_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\Venom_Options.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\Venom_Options.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AutoAttach = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\Venom_Options.xaml"
            this.AutoAttach.Checked += new System.Windows.RoutedEventHandler(this.AutoAttach_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FPS_Booster = ((System.Windows.Controls.CheckBox)(target));
            
            #line 16 "..\..\Venom_Options.xaml"
            this.FPS_Booster.Checked += new System.Windows.RoutedEventHandler(this.FPS_Booster_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AutoLaunch = ((System.Windows.Controls.CheckBox)(target));
            
            #line 17 "..\..\Venom_Options.xaml"
            this.AutoLaunch.Checked += new System.Windows.RoutedEventHandler(this.AutoLaunch_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AlwaysOnTop = ((System.Windows.Controls.CheckBox)(target));
            
            #line 18 "..\..\Venom_Options.xaml"
            this.AlwaysOnTop.Checked += new System.Windows.RoutedEventHandler(this.AlwaysOnTop_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.KillRBLX = ((System.Windows.Controls.CheckBox)(target));
            
            #line 19 "..\..\Venom_Options.xaml"
            this.KillRBLX.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

