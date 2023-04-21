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
using CoffeHause.DB;
using static CoffeHause.ClassHelper.EFclass;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для SaleListWindow.xaml
    /// </summary>
    public partial class SaleListWindow : Window
    {
        public SaleListWindow()
        {
            InitializeComponent();
            if (ClassHelper.UserDataClass.Worker.IdPostWorker != 2)
            {
                btnAddSale.Visibility = Visibility.Collapsed;
                btnDelitSale.Visibility = Visibility.Collapsed;
                btnUpDateWork.Visibility = Visibility.Collapsed;
            }
            GetSale();
            listviewSale.ItemsSource = Contex.Sale.ToList();
            
        }
        private void GetSale()
        {
            List<Sale> saleList = new List<Sale>();

            saleList = Contex.Sale.ToList();

            listviewSale.ItemsSource = saleList;
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
           AddSaleWindow addSaleWindow = new AddSaleWindow();
           addSaleWindow.ShowDialog();
        }

        private void DelitSale_Click()
        {

        }
    }
}
