using CoffeHause.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using static CoffeHause.ClassHelper.BasketClass;

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

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            DB.Product selectedProduct = button.DataContext as DB.Product;
            if (selectedProduct != null)
            {
                selectedProduct.Quantity++;
                int o = Products.IndexOf(selectedProduct);
                Products.Remove(selectedProduct);
                Products.Insert(o, selectedProduct);
            }
            GetListProduct();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

            //    DB.SaleProduct Spoduct = new DB.SaleProduct();
            //    Spoduct.IdProduct = ClassHelper.BasketClass.Products;
            //    Spoduct.IdSale = 
            //    check.IDEmployee = ClassHelper.AuthUserClass.authEmploee.IDEmploee;
            //    check.IDGuest = 1;
            //    check.Date = DateTime.Now;
            //    if (check != null)
            //    {
            //        Context.Check.Add(check);
            //        Context.SaveChanges();
            //    }


            //    foreach (var item in stuffsCart)
            //    {
            //        DataBase.StuffList stuffList = new DataBase.StuffList();
            //        stuffList.IDStuff = item.IDStuff;
            //        stuffList.Quantity = item.Quantity;
            //        stuffList.IDCheck = Context.Check.ToList().LastOrDefault().IDCheck;
            //        Context.StuffList.Add(stuffList);
            //        Context.SaveChanges();
            //    }
            //    MessageBox.Show("Продукты успешно добавлены");
            //    ProductListWindow productListWindow = new ProductListWindow();
            //    productListWindow.Show();
            //    Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Возникла неизвесная ошибка");
            //}
        }
    }
}
