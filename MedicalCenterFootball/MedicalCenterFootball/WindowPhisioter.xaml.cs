using System;
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
using System.Windows.Shapes;

namespace MedicalCenterFootball
{
    /// <summary>
    /// Логика взаимодействия для WindowPhisioter.xaml
    /// </summary>
    public partial class WindowPhisioter : Window
    {
        public WindowPhisioter()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowReportPhisioter windowReportPhisioter = new WindowReportPhisioter();
            windowReportPhisioter.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowKalendarDoctor windowKalendarDoctor = new WindowKalendarDoctor();
            windowKalendarDoctor.Show();
            this.Close();
        }
    }
}
