﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EEC41EC26B62EA08AE8485E58A33F7BFA5DA2343"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
using System.Windows.Controls.Ribbon;
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


namespace Employee_Management_System {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 95 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmployeeIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SalaryTextBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DesignationTextBox;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView EmployeeListView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ManagementSystem;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 78 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EmployeeIdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\MainWindow.xaml"
            this.EmployeeIdTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.EmployeeIdTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\MainWindow.xaml"
            this.EmployeeIdTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.EmployeeIdTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 98 "..\..\..\MainWindow.xaml"
            this.NameTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.NameTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 98 "..\..\..\MainWindow.xaml"
            this.NameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.NameTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 100 "..\..\..\MainWindow.xaml"
            this.EmailTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.EmailTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 100 "..\..\..\MainWindow.xaml"
            this.EmailTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.EmailTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SalaryTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 102 "..\..\..\MainWindow.xaml"
            this.SalaryTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.SalaryTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\MainWindow.xaml"
            this.SalaryTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.SalaryTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DesignationTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\..\MainWindow.xaml"
            this.DesignationTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.DesignationTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 104 "..\..\..\MainWindow.xaml"
            this.DesignationTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.DesignationTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 105 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddEmployeeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EmployeeListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            
            #line 123 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 126 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

