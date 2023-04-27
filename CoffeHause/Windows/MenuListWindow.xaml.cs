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

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuListWindow.xaml
    /// </summary>
    public partial class MenuListWindow : Window
    {
        public MenuListWindow()
        {
            InitializeComponent();
            tbName.Text = ClassHelper.UserDataClass.Worker.LastName+ " " + ClassHelper.UserDataClass.Worker.FirstName + " / " + ClassHelper.UserDataClass.Worker.PostWorker.PostWorker1;
        }

        private void tbProduct_Click(object sender, RoutedEventArgs e)
        {
            ProdListWindow prodListWindow = new ProdListWindow();
            this.Hide();
            prodListWindow.Show();
            this.Show();
        }

        private void tbWorker_Click(object sender, RoutedEventArgs e)
        {
            WorkListWindow workListWindow = new WorkListWindow();
            this.Hide();
            workListWindow.ShowDialog();
            this.Show();
        }

        private void tbOrder_Click(object sender, RoutedEventArgs e)
        {
            SaleListWindow saleListWindow = new SaleListWindow();
            this.Hide();
            saleListWindow.Show();
            this.Show();
        }

        private void tbReport_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            this.Hide();
            reportWindow.Show();
            this.Show();
        }
    }
}
