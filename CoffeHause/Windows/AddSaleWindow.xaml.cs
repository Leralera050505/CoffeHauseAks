using CoffeHause.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using CoffeHause.DB;
using static Microsoft.Win32.OpenFileDialog;
using Microsoft.Win32;
using CoffeHause.ClassHelper;
using static CoffeHause.ClassHelper.EFclass;
using System.Windows.Media.TextFormatting;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSaleWindow.xaml
    /// </summary>
    public partial class AddSaleWindow : Window
    {
        public AddSaleWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sale sale = new Sale();
                DpDate.Text = sale.Date.ToString();
                TbFullCost.Text = sale.FullCost.ToString();
                TbFnameClient.Text = sale.Client.FirstName.ToString();
                TbLnameClient.Text = sale.Client.LastName.ToString();
                MessageBox.Show("Добавление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
