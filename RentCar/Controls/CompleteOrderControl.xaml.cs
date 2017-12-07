﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentCar.Controls
{
    /// <summary>
    /// Interaction logic for CompleteOrderControl.xaml
    /// </summary>
    public partial class CompleteOrderControl : UserControl
    {
        public event EventHandler CompleteCanceled;
        public event EventHandler CompleteSuccessed;

        public CompleteOrderControl()
        {
            InitializeComponent();
        }

        private void CompleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompleteSuccessed != null)
            {
                CompleteSuccessed(this, new EventArgs());
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompleteCanceled != null)
            {
                CompleteCanceled(this, new EventArgs());
            }
        }
    }
}
