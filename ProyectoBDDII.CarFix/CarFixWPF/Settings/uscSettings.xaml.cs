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

namespace CarFixWPF.Settings
{
    /// <summary>
    /// Lógica de interacción para uscSettings.xaml
    /// </summary>
    public partial class uscSettings : UserControl
    {
        public uscSettings()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            winSettingChangePassword win = new winSettingChangePassword();
            win.ShowDialog();
        }
    }
}
