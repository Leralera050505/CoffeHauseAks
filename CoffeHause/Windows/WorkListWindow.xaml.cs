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
using static CoffeHause.ClassHelper.AppData;
using static CoffeHause.ClassHelper.EFclass;


namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkListWindow.xaml
    /// </summary>
    public partial class WorkListWindow : Window
    {
        public WorkListWindow()
        {
            InitializeComponent();
            if (ClassHelper.UserDataClass.Worker.IdPostWorker != 2)
            {
                bntAddWork.Visibility = Visibility.Collapsed;
                btnDelitWork.Visibility = Visibility.Collapsed;
                btnReAdd.Visibility = Visibility.Collapsed;
            }
            GetProducr();
            listviewWorker.ItemsSource = Contex.Worker.ToList();
        }
        private void GetProducr()
        {
            List<Worker> stuffList = new List<Worker>();

            stuffList = Contex.Worker.ToList();

            listviewWorker.ItemsSource = stuffList;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddWorkWindow addWorkWindow = new AddWorkWindow();
            addWorkWindow.Show();
        }

        private void btnDelitWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Worker worker = listviewWorker.SelectedItem as Worker;
                LoginPassword loqinPassword = Contex.LoginPassword.ToList().Where(i => i.Login == worker.Login).FirstOrDefault();
                Contex.Worker.Remove(worker);
                Contex.SaveChanges();
                Contex.LoginPassword.Remove(loqinPassword);
                Contex.SaveChanges();
                listviewWorker.ItemsSource = Contex.Worker.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReAdd_Click_1(object sender, RoutedEventArgs e)
        {

            WorkerEditWindow workerEditWindow = new WorkerEditWindow(listviewWorker.SelectedItem as Worker);
            workerEditWindow.ShowDialog();

        }
    }
}
