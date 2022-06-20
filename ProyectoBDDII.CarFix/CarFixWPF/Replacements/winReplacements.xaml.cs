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
using Microsoft.Win32;
using Tulpep.NotificationWindow;
using System.IO;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;

namespace CarFixWPF.Replacements
{
    /// <summary>
    /// Lógica de interacción para winReplacements.xaml
    /// </summary>
    public partial class winReplacements : Window
    {
        byte op = 0;
        string pathImage = "";
        Replacement r;
        ReplacementDetails rd;
        ReplacementDetailsImpl rdImpl = new ReplacementDetailsImpl();

        public winReplacements()
        {
            InitializeComponent();
        }

        public winReplacements(byte op)
        {
            InitializeComponent();
            this.op = op;          
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboStorehouse();
            FillComboReplacementBrand();
            FillComboCategory();

            if (this.op == 1)
            {
                txtTitle.Text = "INSERTAR NUEVO REPUESTO";
                btnRegister.Content = "INSERTAR";
            }
            else
            {
                txtTitle.Text = "MODIFICAR DATOS DE REPUESTO";
                btnRegister.Content = "MODIFICAR";
            }
        }

        void FillComboStorehouse()
        {
            StorehouseImpl sImpl = new StorehouseImpl();
            try
            {
                cmbStorehouse.ItemsSource = null;
                cmbStorehouse.DisplayMemberPath = "storehouseName";
                cmbStorehouse.SelectedValuePath = "id";
                cmbStorehouse.ItemsSource = sImpl.SelectIDName().DefaultView;
                cmbStorehouse.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void FillComboCategory()
        {
            CategoryImpl cImpl = new CategoryImpl();
            try
            {
                cmbCategory.ItemsSource = null;
                cmbCategory.DisplayMemberPath = "categoryName";
                cmbCategory.SelectedValuePath = "id";
                cmbCategory.ItemsSource = cImpl.SelectIDName().DefaultView;
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void FillComboReplacementBrand()
        {
            ReplacementBrandImpl sImpl = new ReplacementBrandImpl();
            try
            {
                cmbBrand.ItemsSource = null;
                cmbBrand.DisplayMemberPath = "brandName";
                cmbBrand.SelectedValuePath = "id";
                cmbBrand.ItemsSource = sImpl.SelectIDName().DefaultView;
                cmbBrand.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImages_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagen|*.jpg";

            if (ofd.ShowDialog() == true)
            {
                pathImage = ofd.FileName;
                imgEmployee.Source = new BitmapImage(new Uri(pathImage));
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }   

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            switch (op)
            {
                case 1:
                    //Insert
                    if (!string.IsNullOrEmpty(txtRepName.Text.Trim()) && !string.IsNullOrEmpty(txtRepPrice.Text.Trim()) && !string.IsNullOrEmpty(txtCode.Text.Trim()) &&
                        !string.IsNullOrEmpty(txtDescription.Text.Trim()) && !string.IsNullOrEmpty(txtStock.Text.Trim()) && !string.IsNullOrEmpty(cmbBrand.Text.Trim()) &&
                        !string.IsNullOrEmpty(cmbCategory.Text.Trim()) && !string.IsNullOrEmpty(cmbStorehouse.Text.Trim()))
                    {
                        try
                        {
                            r = new Replacement(txtRepName.Text.ToUpper().Trim(), txtRepPrice.Text.ToUpper().Trim(), txtDescription.Text.ToUpper().Trim());
                            rd = new ReplacementDetails(txtCode.Text.ToUpper().Trim(), int.Parse(txtStock.Text.Trim()), byte.Parse(cmbCategory.SelectedValue.ToString().ToUpper()), byte.Parse(cmbBrand.SelectedValue.ToString().ToUpper()), byte.Parse(cmbStorehouse.SelectedValue.ToString().ToUpper()));

                            rd.Photo = DateTime.Now.ToFileTime().ToString();

                            if (pathImage != "")
                            {
                                File.Copy(pathImage, Config.PathPhotoReplacement + rd.Photo + ".jpg");
                            }

                            rdImpl.Insert(r, rd);

                            this.Close();

                            var popupNotifier = new PopupNotifier();
                            popupNotifier.TitleText = "REGISTRO EXITOSO";
                            popupNotifier.ContentText = "Se registro el repuesto de manera exitosa.";
                            popupNotifier.Popup();
                        }
                        catch
                        {
                            MessageBox.Show("Algo malo ocurrio en el sistema\nComuniquese con el Adm. de Sistemas.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("INGRESE TODOS LOS CAMPOS REQUERIDOS", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }                    
                    break;
                case 2:
                    //Update
                    break;
            }
        }
    }
}
