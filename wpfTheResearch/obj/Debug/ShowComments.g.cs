﻿#pragma checksum "..\..\ShowComments.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C18303B91D58701EAB4045B54D9D0355E10EAC03C4236EF0022F6D914D9FAFFD"
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
    /// ShowComments
    /// </summary>
    public partial class ShowComments : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvComments;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView gpoeple;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCommentDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbIdComment;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbCommentTextName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDemarcUser;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDemarcNews;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\ShowComments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDemarcation;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\ShowComments.xaml"
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
            System.Uri resourceLocater = new System.Uri("/wpfTheResearch;component/showcomments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ShowComments.xaml"
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
            this.lvComments = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\ShowComments.xaml"
            this.lvComments.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.lvComments_Click));
            
            #line default
            #line hidden
            
            #line 20 "..\..\ShowComments.xaml"
            this.lvComments.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvComments_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\ShowComments.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gpoeple = ((System.Windows.Controls.GridView)(target));
            return;
            case 4:
            this.txbCommentDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txbIdComment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txbCommentTextName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.cmbDemarcUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cmbDemarcNews = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.btDemarcation = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\ShowComments.xaml"
            this.btDemarcation.Click += new System.Windows.RoutedEventHandler(this.btDemarcation_Click_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btReset = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\ShowComments.xaml"
            this.btReset.Click += new System.Windows.RoutedEventHandler(this.btReset_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
