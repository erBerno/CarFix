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

namespace CarFixWPF.Storehouse
{
    /// <summary>
    /// Lógica de interacción para winStorehouseList.xaml
    /// </summary>
    public partial class winStorehouseList : Window
    {
        StorehouseImpl sImpl = new StorehouseImpl();
        CarFixDAO.Model.Storehouse sh;

        public winStorehouseList()
        {
            InitializeComponent();
        }

        void Select()
        {
            dgvData.ItemsSource = null;

            try
            {
                DataTable dt = sImpl.Select();

                foreach (DataRow row in dt.Rows)
                {
                    row["photo"] = Config.PathPhotoStorehouse + row["photo"] + ".jpg";
                }

                dgvData.ItemsSource = dt.DefaultView;
                dgvData.Columns[1].Visibility = Visibility.Collapsed;
                dgvData.Columns[2].Visibility = Visibility.Collapsed;
            }
            catch 
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvData.SelectedItem != null && dgvData.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgvData.SelectedItem;
                    byte id = byte.Parse(d.Row.ItemArray[1].ToString());
                    sh = sImpl.Get(id);
                    if (sh != null)
                    {
                        new winStorehouseUpdate(sh).Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
