﻿#pragma checksum "..\..\..\Controls\SignInControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1ACB9DBA968A40D6726EF6A54FF2EDCA"
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
    /// SignInControl
    /// </summary>
    public partial class SignInControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Controls\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTxt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Controls\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTxt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Controls\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignInBtn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Controls\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GuestBtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Controls\SignInControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignUpBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RentCar;component/controls/signincontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\SignInControl.xaml"
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
            this.SignInBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Controls\SignInControl.xaml"
            this.SignInBtn.Click += new System.Windows.RoutedEventHandler(this.SignInBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GuestBtn = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Controls\SignInControl.xaml"
            this.GuestBtn.Click += new System.Windows.RoutedEventHandler(this.GuestBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SignUpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Controls\SignInControl.xaml"
            this.SignUpBtn.Click += new System.Windows.RoutedEventHandler(this.SignUpBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 38 "..\..\..\Controls\SignInControl.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
