using Restore_Zadohin3IS_24.Model;
using Restore_Zadohin3IS_24.View.Pages;
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
    /// Логика взаимодействия для AdministratorWindow.xaml
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        public AdministratorWindow(Employee employee)
        {
            App.enteredEmployee = employee;
            InitializeComponent();
            if (employee == App.enteredEmployee)
            {
                WaiterTbl.Text = employee.Name;
                AdminFrm.Navigate(new AdministratorPage(App.enteredEmployee));
            }
        }

        private void ExitProfileMi_Click(object sender, RoutedEventArgs e)
        {
            AuthorizathionWindow authorizathionWindow = new AuthorizathionWindow();
            Close();
            authorizathionWindow.ShowDialog();
        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AccountingMi_Click(object sender, RoutedEventArgs e)
        {
            AncountWindow ancountWindow = new AncountWindow();
            ancountWindow.ShowDialog();
        }
    }
}
