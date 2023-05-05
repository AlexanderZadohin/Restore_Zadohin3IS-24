
using Restore_Zadohin3IS_24.Model;
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
using static Restore_Zadohin3IS_24.App;

namespace Restore_Zadohin3IS_24.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizathionWindow.xaml
    /// </summary>
    public partial class AuthorizathionWindow : Window
    {
        public AuthorizathionWindow()
        {
            InitializeComponent();

        }

        private void PincodeBtn_Click(object sender, RoutedEventArgs e)
        {
            //sender - параметр который хранит в себе объект, среагировавший на событие, можно привести к определнному типу
            PincodePb.Password += (sender as Button).Content.ToString();

            if (PincodePb.Password.Length == 4)
            {
                Employee employee = App.context.Employee.FirstOrDefault(w => w.Pincode == PincodePb.Password);
                if (employee != null)
                {
                    if (employee.RoleId == 1) 
                    {
                        MainWindow mainWindow = new MainWindow(employee);
                        mainWindow.Show();
                        Close();
                    }
                    else if(employee.RoleId == 2)
                    {
                        AdministratorWindow administrator = new AdministratorWindow(employee);
                        administrator.Show();
                        Close();
                    }

                }
                else 
                {
                    MessageBox.Show("Неправильный PIN-code!");
                    PincodePb.Clear();
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PincodePb.Password.Length > 0)
            {
                PincodePb.Password = PincodePb.Password.Remove(PincodePb.Password.Length - 1);
            }
        }
    }
}
