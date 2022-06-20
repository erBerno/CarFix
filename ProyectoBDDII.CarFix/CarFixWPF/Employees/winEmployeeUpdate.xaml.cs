using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.Win32;
using Tulpep.NotificationWindow;

namespace CarFixWPF.Employees
{
    /// <summary>
    /// Lógica de interacción para winEmployeeUpdate.xaml
    /// </summary>
    public partial class winEmployeeUpdate : Window
    {
        TownImpl townImpl = new TownImpl();
        EmployeeImpl eImpl = new EmployeeImpl();
        Employee employee;
        int employeeID;
        string pathImage;

        public winEmployeeUpdate()
        {
            InitializeComponent();
        }

        public winEmployeeUpdate(Employee e)
        {
            InitializeComponent();
            employee = e;
            employeeID = e.Id;
            txtFirstName.Text = e.FirstName;
            txtLastNme.Text = e.LastName;
            txtSecondLastName.Text = e.SecondLastName;
            txtCI.Text = e.Ci;
            txtAddress.Text = e.Address;
            txtPhones.Text = e.Phones;
            txtEmail.Text = e.Email;
            cmbCity.SelectedItem = e.TownName;
            cmbRole.SelectedItem = e.Role;
            string imagePath = Config.PathPhotoEmployee + e.Id + ".jpg";
            imgEmployee.Source = new BitmapImage(new Uri(imagePath));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectTowns();
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).imgLogin.ImageSource = null;
                }
            }
            
            imgEmployee.Source = null;

            //Update
            employee = new Employee(employeeID, txtFirstName.Text.ToUpper(), txtLastNme.Text.ToUpper(), txtSecondLastName.Text.ToUpper(), txtCI.Text, txtEmail.Text, 
                txtAddress.Text.ToUpper(), txtPhones.Text, cmbRole.Text.ToUpper(), cmbCity.Text.ToUpper());
            try
            {
                File.Delete(Config.PathPhotoEmployee + employee.Id + ".jpg");
                File.Copy(pathImage, Config.PathPhotoEmployee + employee.Id + ".jpg");
                var popupNotifier = new PopupNotifier();
                int n = eImpl.Update(employee);            

                if (n > 0)
                {
                    popupNotifier.TitleText = "MODIFICACION EXITOSA";
                    popupNotifier.ContentText = "Registro modificado correctamente.";
                    popupNotifier.Popup();
                    new winEmployeeList().Show();
                    this.Close();
                }
                else
                {
                    popupNotifier.TitleText = "ERROR EN LA MODIFICACION";
                    popupNotifier.ContentText = "Registro no modificado.\nComuniquese con el Administrador\nde Sistemas.";
                    popupNotifier.Popup();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var popupNotifier = new PopupNotifier();
              
            if (MessageBox.Show("Esta realmente segur@ \n de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {                  
                    int n = eImpl.Delete(employee);
                    if (n > 0)
                    {
                        popupNotifier.TitleText = "ELIMINACION EXITOSA";
                        popupNotifier.ContentText = "Registro eliminado correctamente.";
                        popupNotifier.Popup();
                        new winEmployeeList().Show();
                        this.Close();
                    }
                    else
                    {
                        popupNotifier.TitleText = "ERROR EN LA ELIMINACION";
                        popupNotifier.ContentText = "Registro no eliminado.\nComuniquese con el Administrador\nde Sistemas.";
                        popupNotifier.Popup();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
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
