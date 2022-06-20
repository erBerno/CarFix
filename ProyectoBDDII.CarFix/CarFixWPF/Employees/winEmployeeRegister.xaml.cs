using System;
using System.Collections.Generic;
using System.Data;
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
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Tulpep.NotificationWindow;
using Microsoft.Win32;
using System.IO;
using CarFixDAO.Model;

namespace CarFixWPF.Employees
{
    /// <summary>
    /// Lógica de interacción para winEmployeeRegister.xaml
    /// </summary>
    public partial class winEmployeeRegister : Window
    {
        TownImpl townImpl = new TownImpl();
        EmployeeImpl eImpl = new EmployeeImpl();
        CarFixDAO.Model.Employee employee;
        string pathImage = "";

        public winEmployeeRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectTowns()
        {
            DataTable cities = new DataTable();
            try
            {
                cities = townImpl.Select();
                cmbCity.Items.Clear();
                foreach (DataRow row in cities.Rows)
                {
                    cmbCity.Items.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectTowns();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFirstName.Text.Trim()) && !string.IsNullOrEmpty(txtLastNme.Text.Trim()) && !string.IsNullOrEmpty(txtCI.Text.Trim()) &&
                !string.IsNullOrEmpty(txtEmail.Text.Trim()) && !string.IsNullOrEmpty(dpBirthDate.Text.Trim()) && !string.IsNullOrEmpty(cmbGender.Text.Trim()) &&
                !string.IsNullOrEmpty(txtAddress.Text.Trim()) && !string.IsNullOrEmpty(txtPhones.Text.Trim()) && !string.IsNullOrEmpty(cmbRole.Text.Trim()) &&
                !string.IsNullOrEmpty(cmbCity.Text.Trim()) && !string.IsNullOrEmpty(imgEmployee.Source.ToString()))
            {
                //Insert          
                employee = new CarFixDAO.Model.Employee(txtFirstName.Text.ToUpper().Trim(), txtLastNme.Text.ToUpper().Trim(), txtSecondLastName.Text.ToUpper().Trim(),
                    txtCI.Text.Trim(), txtEmail.Text.Trim(), DateTime.Parse(dpBirthDate.SelectedDate.Value.ToShortDateString()),
                    char.Parse(cmbGender.Text), txtAddress.Text.ToUpper().Trim(), txtPhones.Text.Trim(), cmbRole.Text.ToUpper(), cmbCity.Text.ToUpper());
                employee.UserName = GenerateUserName();
                employee.Password = GeneratePassword();

                int id = eImpl.GetGenerateID();

                employee.Photo = id.ToString();
                             
                try
                {
                    int n = eImpl.Insert(employee);

                    if (pathImage != "")
                    {
                        File.Copy(pathImage, Config.PathPhotoEmployee + id + ".jpg");
                    }

                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("proyectocarfix@gmail.com", "CarFix", System.Text.Encoding.UTF8); //Correo de salida
                    correo.To.Add(employee.Email); //Correo destino?
                    correo.Subject = "SU USUARIO Y CONTRASEÑA"; //Asunto
                    correo.Body = "Su nombre de Usuario es: " + employee.UserName + "\nY su contraseña es: " + employee.Password; //Mensaje del correo
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
                    popupNotifier.TitleText = "REGISTRO EXITOSO";
                    popupNotifier.ContentText = "Se envio un correo con el nombre de usuario y la contraseña.\nComunique al empleado.";
                    popupNotifier.Popup();

                    if (n > 0)
                    {
                        this.Close();
                        winEmployeeList win = new winEmployeeList();
                        win.Show();
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
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

        public string GenerateUserName()
        {
            string[] charToRemove = new string[] { "/" };

            string name = txtFirstName.Text.Trim();
            string lastName = txtLastNme.Text.Trim();
            string secondLastName = txtSecondLastName.Text.Trim();
            string date = dpBirthDate.Text;

            foreach (string c in charToRemove)
            {
                date = date.Replace(c, string.Empty);
            }

            char firstOnName = name.First();
            char lastOnName = lastName.First();
            if (secondLastName != string.Empty)
            {
                char firstOnLastName = secondLastName.First();
                string userName = (firstOnName.ToString() + lastOnName.ToString() + firstOnLastName.ToString() + date).ToLower();
                return userName;
            }
            else
            {
                string userName = (firstOnName.ToString() + lastOnName.ToString() + date).ToLower();
                return userName;
            }       
        }

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

        private void btnImages_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen|*.jpg";

            if (ofd.ShowDialog() == true)
            {
                pathImage = ofd.FileName;
                imgEmployee.Source = new BitmapImage(new Uri(pathImage));
            }
        }
    }
}
