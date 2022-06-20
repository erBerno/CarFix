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

namespace CarFixWPF.Replacements
{
    /// <summary>
    /// Lógica de interacción para uscReplacements.xaml
    /// </summary>
    public partial class uscReplacements : UserControl
    {
        public uscReplacements()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            winReplacements winReplacements = new winReplacements(1);
            winReplacements.Show();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            winReplacementsSearch win = new winReplacementsSearch();
            win.Show();
        }
    }
}
