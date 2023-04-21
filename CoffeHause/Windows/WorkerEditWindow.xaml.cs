using CoffeHause.DB;
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

using static CoffeHause.ClassHelper.EFclass;
using static System.Net.Mime.MediaTypeNames;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkerEditWindow.xaml
    /// </summary>
    public partial class WorkerEditWindow : Window
    {
        Worker editworker;
        public WorkerEditWindow(Worker worker)
        {
            InitializeComponent();
            try
            {
                TbLastName.Text = worker.LastName;
                TbName.Text = worker.FirstName;
                TbPatronymic.Text = worker.Patronymic;
                DB.LoginPassword loginPassword = Contex.LoginPassword.ToList().Where(i => i.Login == worker.Login).FirstOrDefault();
                TbLogin.Text = loginPassword.Login;
                TbPassword.Text = loginPassword.Password;

                CbGender.ItemsSource = Contex.Gender.ToList();
                CbGender.DisplayMemberPath = "NameGender";
                CbGender.SelectedItem = Contex.Gender.ToList().Where(i => i.IdGender == worker.IdGender).FirstOrDefault();

                CbPost.ItemsSource = Contex.PostWorker.ToList();
                CbPost.DisplayMemberPath = "PostWorker";
                CbPost.SelectedItem = Contex.PostWorker.ToList().Where(i => i.IdPostWorker == worker.IdPostWorker).FirstOrDefault();
                editworker = worker;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
