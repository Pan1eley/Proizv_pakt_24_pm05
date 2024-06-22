using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MedicalCenterFootball
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = Db.Conn.User.Where(u => u.Login == TbLoginLogin.Text && u.Password == PbLoginPassword.Password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
            else
            {
                Transfer.LoggedUser = user;
                switch (user.IdRole)
                {
                    case 1:
                        WindowDoctor windowDoctor = new WindowDoctor();
                        windowDoctor.Show();
                        this.Close();
                        break;
                    case 2:
                        WindowMasseur windowMasseur = new WindowMasseur();
                        windowMasseur.Show();
                        this.Close();
                        break;
                    case 3:
                        WindowPhisioter windowPhisioter = new WindowPhisioter();
                        windowPhisioter.Show();
                        this.Close();
                        break;
                    case 4:
                        WindowReabilitolog windowReabilitolog = new WindowReabilitolog();
                        windowReabilitolog.Show();
                        this.Close();
                        break;
                }
            }
        }
    }
}
