﻿#pragma checksum "..\..\showAuths.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "025D94E0529DAF48CF64ED3A9E961C8A8E66CD6827DF82F1DECDEA1B342BD969"
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
using wpfTheResearch;


namespace wpfTheResearch {
    
    
    /// <summary>
    /// ShowNews
    /// </summary>
    public partial class ShowNews : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvAuths;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView gpoeple;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbIdUser;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbUserName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDemarcation;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\showAuths.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btReset;
        
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
            System.Uri resourceLocater = new System.Uri("/wpfTheResearch;component/showauths.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\showAuths.xaml"
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
            this.lvAuths = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\showAuths.xaml"
            this.lvAuths.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.lvUsers_Click));
            
            #line default
            #line hidden
            
            #line 20 "..\..\showAuths.xaml"
            this.lvAuths.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\showAuths.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Insert);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\showAuths.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 25 "..\..\showAuths.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.delete);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gpoeple = ((System.Windows.Controls.GridView)(target));
            return;
            case 6:
            this.txbIdUser = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txbUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btDemarcation = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\showAuths.xaml"
            this.btDemarcation.Click += new System.Windows.RoutedEventHandler(this.btDemarcation_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btReset = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\showAuths.xaml"
            this.btReset.Click += new System.Windows.RoutedEventHandler(this.btReset_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

