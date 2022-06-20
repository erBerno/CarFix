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
using CarFixDAO.Implementation;
using CarFixDAO.Model;

namespace CarFixWPF.Settings
{
    /// <summary>
    /// Lógica de interacción para winSettingChangePassword.xaml
    /// </summary>
    public partial class winSettingChangePassword : Window
    {
        public winSettingChangePassword()
        {
            InitializeComponent();
            txtNew.Visibility = Visibility.Collapsed;
            txtConfirm.Visibility = Visibility.Collapsed;
            txtNewPassword.Visibility = Visibility.Collapsed;
            txtConfirmPassword.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl employeeImpl = new EmployeeImpl();
            Employee employee = employeeImpl.Get(SessionClass.sessionUserID);
            if (txtOldPassword.Password == employee.Password)
            {
                if (txtConfirmPassword != null || txtNewPassword != null)
                {
                    if (txtNewPassword.Password.Trim() == txtConfirmPassword.Password.Trim())
                    {
                        employeeImpl.ChangePassword(SessionClass.sessionUserID, txtNewPassword.Password.Trim());
                        MessageBox.Show("Contraseña cambiada con éxito");
                        employeeImpl.ChangeFirstLogin(SessionClass.sessionUserID);
                        this.Close();
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
            else
            {
                MessageBox.Show("Las contraseña no coincide con su contraseña actual", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
