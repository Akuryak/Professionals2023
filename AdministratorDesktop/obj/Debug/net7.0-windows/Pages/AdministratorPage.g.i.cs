﻿#pragma checksum "..\..\..\..\Pages\AdministratorPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67D4BA8B7D6446FFB1B9C9171F08BE11A5086058"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AdministratorDesktop.Pages;
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


namespace AdministratorDesktop.Pages {
    
    
    /// <summary>
    /// AdministratorPage
    /// </summary>
    public partial class AdministratorPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PatronomycTextBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GenderComboBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PostTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\AdministratorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UserPhotoImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AdministratorDesktop;component/pages/administratorpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AdministratorPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Pages\AdministratorPage.xaml"
            ((AdministratorDesktop.Pages.AdministratorPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SurnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PatronomycTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.GenderComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.PostTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\Pages\AdministratorPage.xaml"
            this.SaveButton.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SaveButton_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\..\Pages\AdministratorPage.xaml"
            this.SaveButton.PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SaveButton_PreviewMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Pages\AdministratorPage.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.UserPhotoImage = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            
            #line 61 "..\..\..\..\Pages\AdministratorPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
