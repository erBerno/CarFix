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

namespace CarFixWPF.Employees
{
    /// <summary>
    /// Lógica de interacción para uscEmployee.xaml
    /// </summary>
    public partial class uscEmployee : UserControl
    {
        public uscEmployee()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    winEmployeeRegister win = new winEmployeeRegister();
                    win.ShowDialog();
                    break;
                case 1:
                    winEmployeeList win1 = new winEmployeeList();
                    win1.ShowDialog();
                    break;
            }
        }
    }
}
