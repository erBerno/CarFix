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
                    break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCollapseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Collapsed;
            btnExpandMenu.Visibility = Visibility.Visible;
        }

        private void btnExpandMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Visible;
            btnExpandMenu.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            usc = new Main.uscHome();
            gridMain.Children.Add(usc);
        }
    }
}
