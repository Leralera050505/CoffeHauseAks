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
using System.Xml;
using CoffeHause.DB;
using static CoffeHause.ClassHelper.EFclass;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        List<VW_SaleProduct> saleproduct = new List<VW_SaleProduct>();
        List<string> sortList = new List<string>()
        {
            "По работникам",
            "По клиенту",
            "По цене",
            "По количеству"
        };
        public ReportWindow()
        {

            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            getDate();
            listviewSale.ItemsSource = Contex.VW_SaleProduct.ToList();

        }
       
        void getDate()
        {
            saleproduct = Contex.VW_SaleProduct.ToList();

            saleproduct = saleproduct.Where(j => j.Цена_покупки.ToString().ToLower().Contains(TxbSearch.Text) || j.Дата.ToString().ToLower().Contains(TxbSearch.Text) ||
            j.Клиент.ToString().ToLower().Contains(TxbSearch.Text) ||
            j.Количество.ToString().ToLower().Contains(TxbSearch.Text) ||
            j.Работник.ToString().ToLower().Contains(TxbSearch.Text)).ToList();

            saleproduct = saleproduct.OrderBy(i => i.Дата).ToList();


            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    saleproduct = saleproduct.OrderBy(i => i.Работник).ToList();
                    break;
                case 1:
                    saleproduct = saleproduct.OrderBy(i => i.Клиент).ToList();
                    break;
                case 2:
                    saleproduct = saleproduct.OrderBy(i => i.Цена_покупки).ToList();
                    break;
                case 3:
                    saleproduct = saleproduct.OrderBy(i => i.Количество).ToList();
                    break;
                default:
                    break;
            }

            listviewSale.ItemsSource = saleproduct;
        }



        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getDate();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            getDate();
        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            listviewSale.ItemsSource = Contex.VW_SaleProduct.ToList().Where(i => i.Дата >= dpFirst.SelectedDate && i.Дата <= dpNext.SelectedDate);
        }
    }
}
