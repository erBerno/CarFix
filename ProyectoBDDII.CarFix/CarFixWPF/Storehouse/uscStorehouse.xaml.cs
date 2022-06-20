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
using System.Data;

namespace CarFixWPF.Storehouse
{
    /// <summary>
    /// Lógica de interacción para uscStorehouse.xaml
    /// </summary>
    public partial class uscStorehouse : UserControl
    {
        

        public uscStorehouse()
        {
            InitializeComponent();
        }

        private void btnStorehouses_Click(object sender, RoutedEventArgs e)
        {
            winStorehouse win = new winStorehouse();
            win.ShowDialog();
        }

        private void btnStorehouseL_Click(object sender, RoutedEventArgs e)
        {
            winStorehouseList winL = new winStorehouseList();
            winL.ShowDialog();
        }
    }
}
