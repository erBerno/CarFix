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
using CarFixDAO.Implementation;
using CarFixDAO.Model;
using System.Data;
using Tulpep.NotificationWindow;

namespace CarFixWPF.Employees
{
    /// <summary>
    /// Lógica de interacción para winEmployeeList.xaml
    /// </summary>
    public partial class winEmployeeList : Window
    {
        EmployeeImpl impl = new EmployeeImpl();
        CarFixDAO.Model.Employee employee;

        public winEmployeeList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        void Select()
        {
            dgvData.ItemsSource = null;

            try
            {
                DataTable dt = impl.Select();

                foreach (DataRow row in dt.Rows)
                {
                    row["photo"] = Config.PathPhotoEmployee + row["photo"] + ".jpg";
                }

                dgvData.ItemsSource = dt.DefaultView;
                dgvData.Columns[1].Visibility = Visibility.Collapsed;
                dgvData.Columns[2].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgvData.ItemsSource = null;
            
            try
            {
                dgvData.ItemsSource = impl.Select(txtSearchName.Text).DefaultView;
            }
            catch (Exception ex)
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
                    int id = int.Parse(d.Row.ItemArray[1].ToString());
                    employee = impl.Get(id);
                    if (employee != null)
                    {
                        new winEmployeeUpdate(employee).Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                }
            }
        }
    }
}
