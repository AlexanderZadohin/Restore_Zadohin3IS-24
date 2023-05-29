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

namespace Restore_Zadohin3IS_24.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWaiterWindow.xaml
    /// </summary>
    public partial class AddWaiterWindow : Window
    {
        bool isEdit = false;
        public AddWaiterWindow()
        {
            InitializeComponent();

            isEdit = false;
        }

        public AddWaiterWindow(Employee selectedWaiter)
        {
            InitializeComponent();

            DataContext = selectedWaiter;

            isEdit = true;
        }

        private void AddWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            if(isEdit == true)
            {
                AddWaiterBtn.Content = "Изменить";
                App.context.SaveChanges();

                MessageBox.Show("Позици успешно изменена!");

                DialogResult = true;
            }
            else
            {
                AddWaiterBtn.Content = "Добавить";
                Employee newWaiter = new Employee
                {
                    Name = WaiterNameTB.Text,
                    Pincode = PasswordTB.Text,
                    RoleId = 1
                };
                App.context.Employee.Add(newWaiter);
                App.context.SaveChanges();
                MessageBox.Show("Официант добавлен!", "Потверждение добавления");
                DialogResult = true;
            }
        }
    }
}
