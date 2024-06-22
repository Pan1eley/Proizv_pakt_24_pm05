using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedicalCenterFootball
{

    /// <summary>
    /// Логика взаимодействия для WindowKalendarDoctor.xaml
    /// </summary>
    public partial class WindowKalendarDoctor : Window
    {

        public static Dictionary<DateTime, List<string>> events = new Dictionary<DateTime, List<string>>();

        public WindowKalendarDoctor()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            EventTextBox.Text = "Добавьте запись";
            EventTextBox.Foreground = Brushes.Gray;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDate = ((System.Windows.Controls.Calendar)sender).SelectedDate;

            if (selectedDate.HasValue && events.ContainsKey(selectedDate.Value))
            {
                EventsListBox.ItemsSource = events[selectedDate.Value];
            }
            else
            {
                EventsListBox.ItemsSource = null;
            }
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = Calendar.SelectedDate;

            if (selectedDate.HasValue)
            {
                if (!events.ContainsKey(selectedDate.Value))
                {
                    events[selectedDate.Value] = new List<string>();
                }

                events[selectedDate.Value].Add(EventTextBox.Text);
                EventTextBox.Text = "Добавьте запись";
                EventTextBox.Foreground = Brushes.Gray;

                EventsListBox.ItemsSource = null;
                EventsListBox.ItemsSource = events[selectedDate.Value];

                Calendar.InvalidateVisual();
            }
        }

        private void EventTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EventTextBox.Text == "Добавьте запись")
            {
                EventTextBox.Text = "";
                EventTextBox.Foreground = Brushes.Black;
            }
        }

        private void EventTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EventTextBox.Text))
            {
                EventTextBox.Text = "Добавьте запись";
                EventTextBox.Foreground = Brushes.Gray;
            }
        }

        private void Calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            Calendar.InvalidateVisual();
        }
    }
}

