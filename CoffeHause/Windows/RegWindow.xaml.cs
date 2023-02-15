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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var User = Contex.LoginPassword.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();
            var Worker = Contex.Worker.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            var Client = Contex.Client.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            if ((User != null) && (Worker != null))
            {
                MessageBox.Show("Worker");
            }
            else if ((User != null) && (Client != null))
            {
                MessageBox.Show("Client");
            }
        }

        private void txtReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Reg2Window reg2 = new Reg2Window();
            reg2.Show();
            this.Close();
        }
    }
}
