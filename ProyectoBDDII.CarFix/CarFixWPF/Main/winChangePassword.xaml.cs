using CarFixDAO.Implementation;
using CarFixDAO.Model;
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

namespace CarFixWPF.Main
{
    /// <summary>
    /// Lógica de interacción para winChangePassword.xaml
    /// </summary>
    public partial class winChangePassword : Window
    {
        public winChangePassword()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            winLogin login = new winLogin();
            login.Visibility = Visibility.Hidden;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl employeeImpl = new EmployeeImpl();
            Employee employee = employeeImpl.Get(SessionClass.sessionUserID);
            if (txtConfirmPassword != null || txtNewPassword != null)
            {
                if (txtNewPassword.Password.Trim() == txtConfirmPassword.Password.Trim())
                {                                
                    employeeImpl.ChangePassword(SessionClass.sessionUserID, txtNewPassword.Password.Trim());
                    MessageBox.Show("Contraseña cambiada con éxito");
                    employeeImpl.ChangeFirstLogin(SessionClass.sessionUserID);
                    this.Close();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("INGRESE TODO LOS CAMPOS");
            }
        }
    }
}
