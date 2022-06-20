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

namespace CarFixWPF.ReplacementBrands
{
    /// <summary>
    /// Lógica de interacción para winReplacementBrand.xaml
    /// </summary>
    public partial class winReplacementBrand : Window
    {
        ReplacementBrandImpl impl = new ReplacementBrandImpl();
        CarFixDAO.Model.ReplacementBrand rb;
        byte op = 0;

        public winReplacementBrand()
        {
            InitializeComponent();
        }

        void EnabledButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            txtBrandName.IsEnabled = true;
            txtBrandName.Focus();
        }

        void DisabledButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtBrandName.Clear();
            txtBrandName.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EnabledButtons();
            this.op = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnabledButtons();
            this.op = 2;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EnabledButtons();
            this.op = 3;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.op)
            {
                case 1:
                    //Insert
                    rb = new CarFixDAO.Model.ReplacementBrand(txtBrandName.Text);
                    try
                    {
                        int n = impl.Insert(rb);
                        if (n > 0)
                        {
                            lblInfo.Foreground = Brushes.Green;
                            lblInfo.Content = "Registro insertado con exito - " + DateTime.Now;
                            DisabledButtons();
                            Select();
                        }
                        else
                        {
                            lblInfo.Foreground = Brushes.Red;
                            lblInfo.Content = "No se realizarion inserciones - " + DateTime.Now;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                    }
                    break;
                case 2:
                    //Update
                    rb.BrandName = txtBrandName.Text;
                    try
                    {
                        int n = impl.Update(rb);
                        if (n > 0)
                        {
                            lblInfo.Foreground = Brushes.Green;
                            lblInfo.Content = "Registro modificado con exito - " + DateTime.Now;
                            DisabledButtons();
                            Select();
                        }
                        else
                        {
                            lblInfo.Foreground = Brushes.Red;
                            lblInfo.Content = "No se realizarion actualizaciones - " + DateTime.Now;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                    }
                    break;
                case 3:
                    //Delete
                    if (rb != null)
                    {
                        if (MessageBox.Show("Esta realmente segur@ \n de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                int n = impl.Delete(rb);
                                if (n > 0)
                                {
                                    lblInfo.Foreground = Brushes.Green;
                                    lblInfo.Content = "Registro eliminado con exito - " + DateTime.Now;
                                    DisabledButtons();
                                    Select();
                                }
                                else
                                {
                                    lblInfo.Foreground = Brushes.Red;
                                    lblInfo.Content = "No se eliminaron registros - " + DateTime.Now;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un item a Eliminar");
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisabledButtons();
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvData.SelectedItem != null && dgvData.Items.Count > 0)
            {
                try
                {
                    DataRowView d = (DataRowView)dgvData.SelectedItem;
                    byte id = byte.Parse(d.Row.ItemArray[0].ToString());
                    rb = impl.Get(id);
                    if (rb != null)
                    {
                        txtBrandName.Text = rb.BrandName;
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
            lblInfo.Foreground = Brushes.White;
            lblInfo.Content = dgvData.Items.Count + " Registros Encontrados";
        }

        void Select()
        {
            dgvData.ItemsSource = null;

            try
            {
                dgvData.ItemsSource = impl.Select().DefaultView;
                dgvData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la acción\nComuniquese con el Adm de Sistemas.");
            }
        }
    }
}
