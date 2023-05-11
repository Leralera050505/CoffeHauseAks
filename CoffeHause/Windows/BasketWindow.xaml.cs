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
using CoffeHause.ClassHelper;

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
            decimal price = 0;
            foreach (var item in products)
            {
                price += item.Quantity * item.Cost;
            }
            tbAllCost.Text = price.ToString();
            DateTime datetime = new DateTime();
            datetime = DateTime.Now;
            DateTime testtime = new DateTime(2023, 05, 25);
            PriceWithDiscount(products, testtime);
        }
       public  void PriceWithDiscount(ObservableCollection<Product> products,DateTime datetime)
        {
         
            decimal generalprice = 0;
            foreach (var item in BasketClass.Products)
            {
                generalprice += item.Cost * item.Quantity;
            }
            if (datetime.DayOfWeek == DayOfWeek.Thursday)
            {
                for (int i = 22; i < 28; i++)
                {
                    if (datetime.Day == i)
                    {
                        generalprice = generalprice - (generalprice * (decimal)0.04);
                    }
                }
            }

            generalprice = Math.Round(generalprice, 2);
            tbAllCost.Text = generalprice.ToString();
            tbAllDiscount.Text = Math.Round((generalprice * (decimal)0.04),2).ToString();
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
            ObservableCollection<DB.Product> products= new ObservableCollection<DB.Product>(ClassHelper.BasketClass.Products);
            if (products.Count() == 0)
            {
                MessageBox.Show("Корзина пуста");
            }
            else 
            {
                DB.Sale sale = new DB.Sale();
                sale.IdWorker = (int)ClassHelper.UserDataClass.Worker.IdWorker;
                sale.IdClient = 1;
                sale.Date = DateTime.Now;
                if (sale != null)
                {
                    ClassHelper.EFclass.Contex.Sale.Add(sale);
                    ClassHelper.EFclass.Contex.SaveChanges();
                }

                foreach (var item in ClassHelper.BasketClass.Products)
                {
                    DB.SaleProduct saleProduct = new DB.SaleProduct();
                    saleProduct.IdProduct = item.IdProduct;
                    saleProduct.Quantity= item.Quantity;
                    saleProduct.IdSale = ClassHelper.EFclass.Contex.Sale.ToList().LastOrDefault().IdSale;
                    ClassHelper.EFclass.Contex.SaleProduct.Add(saleProduct);
                    ClassHelper.EFclass.Contex.SaveChanges();
                }
                ClassHelper.BasketClass.Products = new List<DB.Product>();
                MessageBox.Show("Продукты успешно добавлены");
            }
            Close();
        }

        private void BtnRemoveToCart_Click_1(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            DB.Product selectedProduct = button.DataContext as DB.Product;

            if (selectedProduct != null)
            {
                if (selectedProduct.Quantity == 1 || selectedProduct.Quantity == 0)
                {
                    ClassHelper.BasketClass.Products.Remove(selectedProduct);
                }
                else
                {
                    selectedProduct.Quantity--;
                    int o = ClassHelper.BasketClass.Products.IndexOf(selectedProduct);
                    ClassHelper.BasketClass.Products.Remove(selectedProduct);
                    ClassHelper.BasketClass.Products.Insert(o, selectedProduct);
                }

            }
            GetListProduct();
        }
    }
}
