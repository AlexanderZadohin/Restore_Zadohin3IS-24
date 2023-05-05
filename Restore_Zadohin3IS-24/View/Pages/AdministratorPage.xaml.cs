using Restore_Zadohin3IS_24.Model;
using Restore_Zadohin3IS_24.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restore_Zadohin3IS_24.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        public AdministratorPage(Employee enteredEmployee)
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TablesLB.ItemsSource = App.context.Table.ToList();
            WaiterLb.ItemsSource = App.context.Employee.Where(w => w.RoleId == 1).ToList();
            PositionLsb.ItemsSource = App.context.Position.ToList();
        }

        private void TablesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void WaiterLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void PositionLsb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
