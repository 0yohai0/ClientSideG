﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F49951685FBE907ED588B0C4B1E8C27230E6727E8E2A15C5085F5B98416AE867"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HamburgerMenu;
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
using viewModelWpfTheResearch;


namespace viewModelWpfTheResearch {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenu MyMenu;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem Dummy;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiHomePage;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiShowUsers;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiShowAuths;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiShowComments;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiFormula1Game;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmilogOut;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HamburgerMenu.HamburgerMenuItem hmiabout;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame currentFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/wpfTheResearch;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.MyMenu = ((HamburgerMenu.HamburgerMenu)(target));
            return;
            case 2:
            this.Dummy = ((HamburgerMenu.HamburgerMenuItem)(target));
            return;
            case 3:
            this.hmiHomePage = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 20 "..\..\MainWindow.xaml"
            this.hmiHomePage.Selected += new System.Windows.RoutedEventHandler(this.hmiHomePage_Selected);
            
            #line default
            #line hidden
            return;
            case 4:
            this.hmiShowUsers = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 21 "..\..\MainWindow.xaml"
            this.hmiShowUsers.Selected += new System.Windows.RoutedEventHandler(this.hmiShowUsers_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.hmiShowAuths = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 22 "..\..\MainWindow.xaml"
            this.hmiShowAuths.Selected += new System.Windows.RoutedEventHandler(this.hmiShowAuths_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hmiShowComments = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.hmiShowComments.Selected += new System.Windows.RoutedEventHandler(this.hmiShowComments_Selected);
            
            #line default
            #line hidden
            return;
            case 7:
            this.hmiFormula1Game = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 24 "..\..\MainWindow.xaml"
            this.hmiFormula1Game.Selected += new System.Windows.RoutedEventHandler(this.hmiFormula1Game_Selected);
            
            #line default
            #line hidden
            return;
            case 8:
            this.hmilogOut = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.hmilogOut.Selected += new System.Windows.RoutedEventHandler(this.hmilogOut_Selected);
            
            #line default
            #line hidden
            return;
            case 9:
            this.hmiabout = ((HamburgerMenu.HamburgerMenuItem)(target));
            
            #line 26 "..\..\MainWindow.xaml"
            this.hmiabout.Selected += new System.Windows.RoutedEventHandler(this.hmiabout_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            this.currentFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

