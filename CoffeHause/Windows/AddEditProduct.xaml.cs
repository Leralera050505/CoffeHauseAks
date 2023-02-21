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

using System.IO;
using CoffeHause.DB;
using static Microsoft.Win32.OpenFileDialog;
using Microsoft.Win32;
using CoffeHause.ClassHelper;
using static CoffeHause.ClassHelper.EFclass;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        string pathPhoto;
        public AddEditProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.NameProduct = TbProductName.Text;
            product.Cost = Convert.ToDecimal(TbProductCost.Text);
            product.Photo = File.ReadAllBytes(pathPhoto);


            Contex.Product.Add(product);
            Contex.SaveChanges();
            MessageBox.Show("Добавление прошло успешно");
        }

        private void btnselect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if(OFD.ShowDialog() == true)
            {
                ProductImg.Source = new BitmapImage(new Uri(OFD.FileName));

                pathPhoto = OFD.FileName;
            }
        }
    }
}
