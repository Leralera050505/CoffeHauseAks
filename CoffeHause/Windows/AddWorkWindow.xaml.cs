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
using static Microsoft.Win32.OpenFileDialog;
using Microsoft.Win32;
using CoffeHause.ClassHelper;
using static CoffeHause.ClassHelper.EFclass;
using System.Windows.Media.TextFormatting;

namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkWindow.xaml
    /// </summary>
    public partial class AddWorkWindow : Window
    {
        public AddWorkWindow()
        {
            InitializeComponent();
            CbPost.ItemsSource = Contex.PostWorker.ToList();
            CbPost.SelectedIndex = 0;
            CbPost.DisplayMemberPath = "PostWorker1";

            CbGender.ItemsSource = Contex.Gender.ToList();
            CbGender.SelectedIndex = 0;
            CbGender.DisplayMemberPath = "NameGender";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                

                PostWorker postWorker = new PostWorker();
                postWorker.PostWorker1 = (CbPost.SelectedItem as DB.PostWorker).PostWorker1;
                Contex.PostWorker.Add(postWorker);
                Contex.SaveChanges();
            LoginPassword loginPassword = new LoginPassword();
            loginPassword.Password = TbPassword.Text;
            loginPassword.Login = TbLogin.Text;
            Contex.LoginPassword.Add(loginPassword);
            Contex.SaveChanges();
            Worker worker = new Worker();

            worker.LastName = TbLastName.Text;
            worker.FirstName = TbName.Text;
            worker.Patronymic = TbPatronymic.Text;
            worker.Login = TbLogin.Text;
            worker.IdGender = (CbGender.SelectedItem as DB.Gender).IdGender;
            Contex.Worker.Add(worker);
            Contex.SaveChanges();

            MessageBox.Show("Добавление прошло успешно");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
