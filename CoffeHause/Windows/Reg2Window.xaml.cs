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

using CoffeHause.ClassHelper;
using static CoffeHause.ClassHelper.EFclass;
namespace CoffeHause.Windows
{
    /// <summary>
    /// Логика взаимодействия для Reg2Window.xaml
    /// </summary>
    public partial class Reg2Window : Window
    {
        public Reg2Window()
        {
            InitializeComponent();

            CbGender.ItemsSource = Contex.Gender.ToList();
            CbGender.SelectedIndex = 0;
            CbGender.DisplayMemberPath = "Gender1";
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }
            var User = Contex.LoginPassword.ToList()
             .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();
            var Worker = Contex.Worker.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            var Client = Contex.Client.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
      
            if ((User != null) && (Worker != null))
            {
                MessageBox.Show("Логин занят");
            }
            else if ((User != null) && (Client != null))
            {
                MessageBox.Show("Логин занят");
            }

            DB.Client client = new DB.Client();
            DB.LoginPassword loginPassword = new DB.LoginPassword();
            client.LastName = TbLastName.Text;
            client.FirstName = TbNAme.Text;
            client.Patronymic = TbPatronymic.Text;
            client.IdGender = (CbGender.SelectedItem as DB.Gender).IdGender;
            client.Phone = TbPhone.Text;
            loginPassword.Login = TbLogin.Text;
            loginPassword.Password = TbPassword.Text;

            Contex.LoginPassword.Add(loginPassword);
            client.Login = TbLogin.Text;
            Contex.Client.Add(client);
            Contex.SaveChanges();
            MessageBox.Show("Добавление прошло успешно");

        }
    }
}
