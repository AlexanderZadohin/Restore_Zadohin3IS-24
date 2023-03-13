using Authorizathion.Model;
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

namespace Authorizathion.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void interBtn_Click(object sender, RoutedEventArgs e)
        {
            Waiter waiter = App.context.Waiter.FirstOrDefault(w => w.Pincode == PassworPb.Password && w.Name == NameTb.Text);

            if (waiter != null)
            {
                InterWin interWin = new InterWin();
                interWin.Show();
                Close();
            }

            else
            {
                MessageBox.Show("Неправильно введены данные!");
                PassworPb.Clear();
                NameTb.Clear();
            }
        }
    }
}
