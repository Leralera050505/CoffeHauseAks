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
        string orderby = "Не выбрано";
        List<VW_SaleProduct> saleproduct = new List<VW_SaleProduct>();
        List<string> sortList = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По предмету",
            "По группе"
        };
        void getDate(DatePicker dateF, DatePicker dateN)
        {
            DateO.ItemsSource = ClassHelper.EFclass.Contex.VW_SaleProduct.ToList().Where(i => i.Дата >= dateF.SelectedDate && i.Дата <= dateN.SelectedDate);
        }
        public ReportWindow()
        {
            InitializeComponent();
            listviewSale.ItemsSource = Contex.VW_SaleProduct.ToList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saleproduct = Contex.VW_SaleProduct.ToList();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            saleproduct = Contex.VW_SaleProduct.ToList();
        }
    }
}
