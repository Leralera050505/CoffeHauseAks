using CoffeHause.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static CoffeHause.ClassHelper.EFclass;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        public BasketWindow()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetListProduct()
        {
            ObservableCollection<DB.Product> products = new ObservableCollection<DB.Product>(ClassHelper.BasketClass.Products);
            LVBasket.ItemsSource = products;
        }
        
        private void BtnRemoveToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as DB.Product;


            if (selectedProduct != null)
            {
               ClassHelper.BasketClass.Products.Remove(selectedProduct);
            }
            GetListProduct();
        }
    }
}
