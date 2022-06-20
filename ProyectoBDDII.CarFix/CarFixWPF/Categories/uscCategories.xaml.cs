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

namespace CarFixWPF.Categories
{
    /// <summary>
    /// Lógica de interacción para uscCategories.xaml
    /// </summary>
    public partial class uscCategories : UserControl
    {
        public uscCategories()
        {
            InitializeComponent();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            winCategories win = new winCategories();
            win.Show();
        }
    }
}
