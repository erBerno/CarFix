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
using Microsoft.Win32;
using Tulpep.NotificationWindow;
using Microsoft.Maps.MapControl.WPF;
using System.Data;
using System.IO;

namespace CarFixWPF.Storehouse
{
    /// <summary>
    /// Lógica de interacción para winStorehouseUpdate.xaml
    /// </summary>
    public partial class winStorehouseUpdate : Window
    {

        bool cambiarImagen = false;
        TownImpl townImpl = new TownImpl();
        StorehouseImpl sImpl = new StorehouseImpl();
        CarFixDAO.Model.Storehouse storehouse;
        Location point = new Location();
        byte storehouseID;
        string pathImage;

        public winStorehouseUpdate()
        {
            InitializeComponent();
        }

        public winStorehouseUpdate(CarFixDAO.Model.Storehouse sth)
        {
            InitializeComponent();
            storehouse = sth;           
            txtFirstName.Text = sth.StoreHouseName;
            cmbCity.SelectedItem = sth.TownName;
            Location l = new Location(sth.Latitude, sth.Longitude);
            Pushpin p = new Pushpin();
            myMap.Center = l;
            p.Location = l;
            myMap.Children.Clear();
            myMap.Children.Add(p);
            string imagePath = Config.PathPhotoStorehouse + sth.Photo + ".jpg";
            imgStorehouse.Source = new BitmapImage(new Uri(imagePath));
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

            cambiarImagen = true;
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            //Update
            storehouse = new CarFixDAO.Model.Storehouse(storehouse.Id, txtFirstName.Text.ToUpper(), point.Latitude, point.Longitude, cmbCity.Text.ToUpper(), storehouse.Photo);

            try
            {
                if (cambiarImagen == true)
                {    
                    storehouse.Photo = DateTime.Now.ToFileTime().ToString();
                    File.Copy(pathImage, Config.PathPhotoStorehouse + storehouse.Photo + ".jpg");
                }

                var popupNotifier = new PopupNotifier();
                int n = sImpl.Update(storehouse);

                if (n > 0)
                {
                    popupNotifier.TitleText = "MODIFICACION EXITOSA";
                    popupNotifier.ContentText = "Registro modificado correctamente.";
                    popupNotifier.Popup();
                    new winStorehouseList().Show();
                    this.Close();
                }
                else
                {
                    popupNotifier.TitleText = "ERROR EN LA MODIFICACION";
                    popupNotifier.ContentText = "Registro no modificado.\nComuniquese con el Administrador\nde Sistemas.";
                    popupNotifier.Popup();
                }
            }
            catch 
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var popupNotifier = new PopupNotifier();

            if (MessageBox.Show("Esta realmente segur@ \n de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    //File.Delete(Config.PathPhotoStorehouse + storehouse.Photo + ".jpg");
                    int n = sImpl.Delete(storehouse);
                    if (n > 0)
                    {
                        popupNotifier.TitleText = "ELIMINACION EXITOSA";
                        popupNotifier.ContentText = "Registro eliminado correctamente.";
                        popupNotifier.Popup();
                        new winStorehouseList().Show();
                        this.Close();
                    }
                    else
                    {
                        popupNotifier.TitleText = "ERROR EN LA ELIMINACION";
                        popupNotifier.ContentText = "Registro no eliminado.\nComuniquese con el Administrador\nde Sistemas.";
                        popupNotifier.Popup();
                    }
                }
                catch 
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
            }
        }
    }
}
