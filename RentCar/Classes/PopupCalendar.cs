using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Controls;
using System.Windows;
using System.Windows.Input;

namespace RentCar
{
    public static class PopupCalendar
    {
        private static CalendarPopupControl popupCalControl;


        public static readonly DependencyProperty StateProperty =
            DependencyProperty.RegisterAttached("State",
                                                typeof(CalendarState),
                                                typeof(PopupCalendar),
                                                new FrameworkPropertyMetadata(CalendarState.Normal,
                                                                              OnStateChanged));

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static CalendarState GetState(DependencyObject element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return (CalendarState)element.GetValue(StateProperty);
        }

        public static void SetState(DependencyObject element, CalendarState value)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            element.SetValue(StateProperty, value);
        }


        private static void OnStateChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = element as FrameworkElement;

            if ((frameworkElement != null) && (popupCalControl != null))
            {
                popupCalControl.State = GetState(frameworkElement);
            }
        }

        public static readonly DependencyProperty TargetTextBox =
           DependencyProperty.RegisterAttached("TargetTextBox",
                                               typeof(UIElement),
                                               typeof(PopupCalendar),
                                               new FrameworkPropertyMetadata(null,
                                                                             OnPlacementTargetChanged));
        private static void OnPlacementTargetChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = element as FrameworkElement;

            if (popupCalControl == null) popupCalControl = new CalendarPopupControl();
            if ((frameworkElement != null) && (popupCalControl != null))
            {
                popupCalControl.TargetTextBox = GetTargetTextBox(frameworkElement);
                frameworkElement.AddHandler(UIElement.GotKeyboardFocusEvent,
                                                new KeyboardFocusChangedEventHandler(FrameworkElementGotKeyboardFocus),
                                                true);
                frameworkElement.AddHandler(UIElement.LostKeyboardFocusEvent,
                                            new KeyboardFocusChangedEventHandler(FrameworkElementLostKeyboardFocus),
                                            true);
            }

        }

        private static void FrameworkElementGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;

            if (frameworkElement != null)
            {
                if (popupCalControl == null)
                {
                    popupCalControl = new CalendarPopupControl();

                }

                popupCalControl.TargetTextBox = GetTargetTextBox(frameworkElement);
                popupCalControl.IsOpen = true;


            }
        }

        private static void FrameworkElementLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;

            if (frameworkElement != null)
            {
                if (popupCalControl != null)
                {
                    // Retrieves the setting for the State property
                    SetState(frameworkElement, popupCalControl.State);

                    popupCalControl.IsOpen = false;
                    popupCalControl = null;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static UIElement GetTargetTextBox(DependencyObject element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return (UIElement)element.GetValue(TargetTextBox);
        }

        public static void SetTargetTextBox(DependencyObject element, UIElement value)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            element.SetValue(TargetTextBox, value);
        }
    }
}
