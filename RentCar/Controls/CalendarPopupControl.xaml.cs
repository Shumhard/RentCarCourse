using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для CalandarPopupControl.xaml
    /// </summary>
    public partial class CalendarPopupControl : UserControl
    {
        public CalendarPopupControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var textBox = TargetTextBox as TextBox;

            if (textBox != null)
            {
                var dateTime = GetDate(textBox);
                if (calendarControl.SelectedDates.Count == 0)
                    calendarControl.SelectedDates.Add(dateTime);
                else
                    calendarControl.SelectedDates[0] = dateTime;
                calendarControl.DisplayDate = dateTime;

            }

            calendarControl.SelectedDatesChanged += CalandarControlSelectedDatesChanged;
        }

        private Popup parentPopup;

        private static DateTime GetDate(TextBox textBox)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            DateTime dateTime;

            if ((!string.IsNullOrEmpty(textBox.Text) && DateTime.TryParseExact(textBox.Text, culture.DateTimeFormat.ShortDatePattern, null,
                                       DateTimeStyles.None, out dateTime)))
            {

            }
            else
            {
                dateTime = DateTime.Today;
            }
            return dateTime;
        }
        void CalandarControlSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (calendarControl.SelectedDate.HasValue)
            {
                var textBox = TargetTextBox as TextBox;
                var culture = Thread.CurrentThread.CurrentCulture;
                if (textBox != null)
                    textBox.Text = calendarControl.SelectedDate.Value.ToString(culture.DateTimeFormat.ShortDatePattern);
                this.IsOpen = false;
            }
        }



        public static readonly DependencyProperty TargetTextboxProperty =
            Popup.PlacementTargetProperty.AddOwner(typeof(CalendarPopupControl));

        public UIElement TargetTextBox
        {
            get { return (UIElement)GetValue(TargetTextboxProperty); }
            set { SetValue(TargetTextboxProperty, value); }
        }


        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State",
                                        typeof(CalendarState),
                                        typeof(CalendarPopupControl),
                                        new FrameworkPropertyMetadata(CalendarState.Normal,
                                                                      new PropertyChangedCallback(StateChanged)));

        public CalendarState State
        {
            get { return (CalendarState)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }


        private static void StateChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (CalendarPopupControl)element;

            if ((CalendarState)e.NewValue == CalendarState.Normal)
            {
                ctrl.IsOpen = true;
            }
            else if ((CalendarState)e.NewValue == CalendarState.Hidden)
            {
                ctrl.IsOpen = false;
            }
        }
        public static readonly DependencyProperty IsOpenProperty =
         Popup.IsOpenProperty.AddOwner(
             typeof(CalendarPopupControl),
             new FrameworkPropertyMetadata(
                 false,
                 FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                 IsOpenChanged));
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        private static void IsOpenChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = (CalendarPopupControl)element;

            if ((bool)e.NewValue)
            {
                if (ctrl.parentPopup == null)
                {
                    ctrl.HookupParentPopup();
                }

            }

        }

        private void HookupParentPopup()
        {
            parentPopup = new Popup { AllowsTransparency = false, PopupAnimation = PopupAnimation.Scroll };

            Popup.CreateRootPopup(parentPopup, this);
        }
    }

    public enum CalendarState
    {
        Normal,
        Hidden
    }
}
