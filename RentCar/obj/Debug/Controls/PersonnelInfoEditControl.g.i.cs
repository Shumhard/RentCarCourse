﻿#pragma checksum "..\..\..\Controls\PersonnelInfoEditControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B1C58304E49DE0A194E5B25BCDD121FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// PersonnelInfoEditControl
    /// </summary>
    public partial class PersonnelInfoEditControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PhotoPanel;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadImageBtn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel EditPanel;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveBtn;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
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
            System.Uri resourceLocater = new System.Uri("/RentCar;component/controls/personnelinfoeditcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
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
            this.PhotoPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.LoadImageBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
            this.LoadImageBtn.Click += new System.Windows.RoutedEventHandler(this.LoadImageBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.SaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
            this.SaveBtn.Click += new System.Windows.RoutedEventHandler(this.SaveBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\Controls\PersonnelInfoEditControl.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

