﻿#pragma checksum "..\..\..\Controls\SignUpControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39EBB404AA1EC4B06022A3067C942566"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using RentCar.Controls;
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


namespace RentCar.Controls {
    
    
    /// <summary>
    /// SignUpControl
    /// </summary>
    public partial class SignUpControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTxt;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordRepeatTxt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTxt;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTxt;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsAgree;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignUpBtn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Controls\SignUpControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignUpCancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RentCar;component/controls/signupcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\SignUpControl.xaml"
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
            this.LoginTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.PasswordTxt = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.PasswordRepeatTxt = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.PhoneTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.EmailTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.IsAgree = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            
            #line 39 "..\..\..\Controls\SignUpControl.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SignUpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Controls\SignUpControl.xaml"
            this.SignUpBtn.Click += new System.Windows.RoutedEventHandler(this.SignUpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SignUpCancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Controls\SignUpControl.xaml"
            this.SignUpCancelBtn.Click += new System.Windows.RoutedEventHandler(this.SignUpCancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
