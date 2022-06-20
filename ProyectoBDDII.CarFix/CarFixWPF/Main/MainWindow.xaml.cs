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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarFixDAO.Model;
using CarFixDAO.Implementation;
using System.IO;

namespace CarFixWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserControl usc = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    usc = new Main.uscHome();
                    gridMain.Children.Add(usc);
                    break;
                case 1:
                    usc = new ReplacementBrands.uscReplacementBrand();
                    gridMain.Children.Add(usc);
                    break;
                case 2:
                    usc = new Storehouse.uscStorehouse();
                    gridMain.Children.Add(usc);
                    break;
                case 3:
                    usc = new Employees.uscEmployee();
                    gridMain.Children.Add(usc);
                    break;
                case 4:
                    usc = new Settings.uscSettings();
                    gridMain.Children.Add(usc);
                    break;
                case 5:
                    usc = new Replacements.uscReplacements();
                    gridMain.Children.Add(usc);
                    break;
                case 6:
                    usc = new Categories.uscCategories();
                    gridMain.Children.Add(usc);
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = SessionClass.sessionFirstName + " " + SessionClass.sessionLastName + " " + SessionClass.sessionSecondLastName + " - " + SessionClass.sessionRole;
            txtCity.Text = SessionClass.sessionProvince + " - " + SessionClass.sessionTown;

            string imagePath = SessionClass.sessionPhotoEmployee + SessionClass.sessionUserID + ".jpg";
            string imageDefault = @"D:\OneDrive - Universidad Privada del Valle\3° SEMESTRE\BASES DE DATOS II\Proyecto Final - Bases de Datos II\ProyectoBDDII.CarFix\CarFixWPF\Imgs\user.jpg";
            if (!File.Exists(imagePath))
            {
                imgLogin.ImageSource = new BitmapImage(new Uri(imageDefault, UriKind.RelativeOrAbsolute));
            }
            else
            {
                imgLogin.ImageSource = new BitmapImage(new Uri(imagePath));
            }       
                      
            usc = new Main.uscHome();
            gridMain.Children.Add(usc);

            switch (SessionClass.sessionRole.ToUpper())
            {
                case "ADMINISTRADOR":
                    break;
                case "JEFE DE REPUESTOS":
                    btnUsers.Visibility = Visibility.Collapsed;
                    break;
                case "ENCARGADO DE INFORMACION":
                    btnUsers.Visibility = Visibility.Collapsed;
                    btnStorehouses.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCloseSession_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Main.winLogin winLogin = new Main.winLogin();
            winLogin.Visibility = Visibility.Visible;
        }
    }
}
