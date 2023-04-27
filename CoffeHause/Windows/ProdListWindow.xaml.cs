using CoffeHause.DB;
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

using static CoffeHause.ClassHelper.EFclass;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProdListWindow.xaml
    /// </summary>
    public partial class ProdListWindow : Window
    {
        public ProdListWindow()
        {
            InitializeComponent();

            List<Product> products = new List<Product>();

            products = Contex.Product.ToList();

            LVProdList.ItemsSource = products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProduct = new AddEditProduct();
            addEditProduct.Show();
            this.Close();

        }

        private void btnBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow basketWindow = new BasketWindow();
            basketWindow.ShowDialog();
            this.Hide();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            bool seek = true;
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            DB.Product selectedProduct = button.DataContext as DB.Product;
            if (selectedProduct != null)
            {
                for (int i = 0; i < ClassHelper.BasketClass.Products.Count; i++)
                {
                    if (ClassHelper.BasketClass.Products[i] == selectedProduct)
                    {
                        ClassHelper.BasketClass.Products[i].Quantity++;
                        seek = false;
                    }
                }
                if(seek)
                {
                    selectedProduct.Quantity = 1;
                    ClassHelper.BasketClass.Products.Add(selectedProduct);
                }
            }
        }
    }
}
