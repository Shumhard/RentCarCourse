﻿#pragma checksum "..\..\..\Controls\CompleteOrderControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6191267C0D83843143F84C8790B44728"
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
    /// CompleteOrderControl
    /// </summary>
    public partial class CompleteOrderControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 35 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BeginRentDate;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndRentDate;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AddServicesListBox;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CashBtn;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton BankBtn;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CompleteBtn;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Controls\CompleteOrderControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/RentCar;component/controls/completeordercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\CompleteOrderControl.xaml"
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
            
            #line 8 "..\..\..\Controls\CompleteOrderControl.xaml"
            ((RentCar.Controls.CompleteOrderControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.BeginRentDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.EndRentDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddServicesListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.CashBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.BankBtn = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.CompleteBtn = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\Controls\CompleteOrderControl.xaml"
            this.CompleteBtn.Click += new System.Windows.RoutedEventHandler(this.CompleteBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Controls\CompleteOrderControl.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

