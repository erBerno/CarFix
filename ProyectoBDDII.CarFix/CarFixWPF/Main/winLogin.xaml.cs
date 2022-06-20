using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using Tulpep.NotificationWindow;
using CarFixDAO.Model;
using CarFixDAO.Implementation;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace CarFixWPF.Main
{
    /// <summary>
    /// Lógica de interacción para winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        EmployeeImpl employeeImpl = new EmployeeImpl();

        public winLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            EmployeeImpl implEmployee = new EmployeeImpl();
            DataTable table = new DataTable();
            var popupNotifier = new PopupNotifier();

            if (!string.IsNullOrEmpty(txtUsername.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Password.Trim()))
            {
                try
                {
                    table = implEmployee.Login(txtUsername.Text.Trim(), txtPassword.Password.Trim());
                    if (table.Rows.Count > 0)
                    {
                        SessionClass.sessionUserID = int.Parse(table.Rows[0][0].ToString());
                        SessionClass.sessionUserName = table.Rows[0][1].ToString();
                        SessionClass.sessionRole = table.Rows[0][2].ToString();
                        SessionClass.sessionFirstName = table.Rows[0][3].ToString();
                        SessionClass.sessionLastName = table.Rows[0][4].ToString();
                        SessionClass.sessionSecondLastName = table.Rows[0][5].ToString();
                        SessionClass.sessionProvince = table.Rows[0][6].ToString();
                        SessionClass.sessionTown = table.Rows[0][7].ToString();
                        SessionClass.sessionFirstTime = table.Rows[0][8].ToString();

                        ConfigImpl configImpl = new ConfigImpl();

                        DataTable tableConfig = configImpl.Select();

                        Config.PathPhotoEmployee = tableConfig.Rows[0][0].ToString();
                        SessionClass.sessionPhotoEmployee = tableConfig.Rows[0][0].ToString();

                        Config.PathPhotoStorehouse = tableConfig.Rows[0][1].ToString();
                        SessionClass.sessionPhotoStorehouse = tableConfig.Rows[0][1].ToString();

                        Config.PathPhotoReplacement = tableConfig.Rows[0][2].ToString();
                        SessionClass.sessionPhotoReplacement = tableConfig.Rows[0][2].ToString();

                        if (SessionClass.sessionFirstTime == "1")
                        {
                            winChangePassword winChagePassword = new winChangePassword();
                            winChagePassword.Show();

                            popupNotifier.TitleText = "RESTABLECIMIENTO DE CONTRASEÑA";
                            popupNotifier.ContentText = "Debe reestablecer su contraseña obligatoriamente antes de entrar.\nNo comparta dicha contraseña.";
                            popupNotifier.Popup();
                        }
                        else
                        {
                            MainWindow win = new MainWindow();
                            win.Show();
                            this.Visibility = Visibility.Hidden;

                            popupNotifier.TitleText = "INICIO DE SESION";
                            popupNotifier.ContentText = "Inicio de sesión correcto.\nBienvenido de nuevo!";
                            popupNotifier.Popup();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrectos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        btnReset.Visibility = Visibility.Visible;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
            }
            else
            {
                MessageBox.Show("INGRESE TODOS LOS CAMPOS REQUERIDOS", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnReset.Visibility = Visibility.Collapsed;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            string newPass = GeneratePassword();

            employeeImpl.ChangePassword(txtUsername.Text, newPass);

            string email = employeeImpl.GetEmail(txtUsername.Text.Trim()).Email;

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("proyectocarfix@gmail.com", "CarFix", System.Text.Encoding.UTF8); //Correo de salida
            correo.To.Add(email); //Correo destino?
            correo.Subject = "SU NUEVA CONTRASEÑA"; //Asunto
            correo.Body = "Su nueva contraseña es: " + newPass + "\nPorfavor procure no olvidar su contraseña."; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 587; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("proyectocarfix@gmail.com", "ggmcsanufdyzsmkm"); //Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true; //True si el servidor de correo permite ssl
            smtp.Send(correo);

            var popupNotifier = new PopupNotifier();
            popupNotifier.TitleText = "CORREO ENVIADO EXITOSAMENTE";
            popupNotifier.ContentText = "Se envio un correo con su nueva contraseña.\nRevise su correo.";
            popupNotifier.Popup();

            txtPassword.Password = "";
            txtUsername.IsEnabled = false;
        }

        #region GENERADOR DE CONTRASEÑAS
        static List<char> chars = new List<char>();

        static string GeneratePassword()
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            int j = 0;
            addChars(ref chars);
            while (j < 9)
            {
                sb.Append(chars[rnd.Next(0, chars.Count)]);
                j++;
            }
            return sb.ToString();
        }

        static void addChars(ref List<char> chars)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                chars.Add(c);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                chars.Add(c);
            }
            for (char c = '1'; c <= '9'; c++)
            {
                chars.Add(c);
            }
        }
        #endregion
    }
}
