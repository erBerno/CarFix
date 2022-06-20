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
using CarFixDAO.Model;
using CarFixDAO.Implementation;
using System.Data;
using Microsoft.Win32;
using Microsoft.Maps.MapControl.WPF;
using System.IO;
using Tulpep.NotificationWindow;

namespace CarFixWPF.Storehouse
{
    /// <summary>
    /// Lógica de interacción para winStorehouse.xaml
    /// </summary>
    public partial class winStorehouse : Window
    {
        TownImpl townImpl = new TownImpl();
        StorehouseImpl impl = new StorehouseImpl();
        CarFixDAO.Model.Storehouse sh;
        string pathImage;
        Location point;

        public winStorehouse()
        {        
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnImages_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen|*.jpg";

            if (ofd.ShowDialog() == true)
            {
                pathImage = ofd.FileName;
                imgStorehouse.Source = new BitmapImage(new Uri(pathImage));
            }
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.ZoomLevel++;
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.ZoomLevel--;
        }

        private void btnRoad_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.Mode = new RoadMode();
        }

        private void btnAerial_Click(object sender, RoutedEventArgs e)
        {
            myMap.Focus();
            myMap.Mode = new AerialMode(true);
        }

        private void myMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePosition = e.GetPosition((UIElement)sender);
            point = myMap.ViewportPointToLocation(mousePosition);

            Pushpin p = new Pushpin();
            p.Location = point;
            myMap.Children.Clear();
            myMap.Children.Add(p);
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
            catch 
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
            if (!string.IsNullOrEmpty(txtFirstName.Text.Trim()) && !string.IsNullOrEmpty(cmbCity.Text.Trim()) && !string.IsNullOrEmpty(imgStorehouse.Source.ToString()) && !string.IsNullOrEmpty(myMap.Children.ToString()))
            {
                //Insert
                sh = new CarFixDAO.Model.Storehouse(txtFirstName.Text.Trim().ToUpper(), point.Latitude, point.Longitude, cmbCity.Text.ToUpper());

                sh.Photo = DateTime.Now.ToFileTime().ToString();

                try
                {
                    int n = impl.Insert(sh);

                    if (pathImage != "")
                    {
                        File.Copy(pathImage, Config.PathPhotoStorehouse + sh.Photo + ".jpg");
                    }

                    var popupNotifier = new PopupNotifier();
                    popupNotifier.TitleText = "REGISTRO EXITOSO";
                    popupNotifier.ContentText = "Se registro el almacen de manera exitosa.";
                    popupNotifier.Popup();

                    if (n > 0)
                    {
                        this.Close();
                        winStorehouseList win = new winStorehouseList();
                        win.Show();
                    }
                    else
                    {
                        MessageBox.Show("ERROR");
                    }
                }
                catch 
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
            }
            else
            {
                MessageBox.Show("INGRESE TODOS LOS CAMPOS REQUERIDOS", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
