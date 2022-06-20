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

namespace CarFixWPF.ReplacementBrands
{
    /// <summary>
    /// Lógica de interacción para uscReplacementBrand.xaml
    /// </summary>
    public partial class uscReplacementBrand : UserControl
    {
        public uscReplacementBrand()
        {
            InitializeComponent();
        }

        private void btnReplacementT_Click(object sender, RoutedEventArgs e)
        {
            winReplacementBrand win = new winReplacementBrand();
            win.Show();
        }
    }
}
