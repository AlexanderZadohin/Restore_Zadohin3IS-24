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
        Position selectPosition;
        Table selectTable;
        Employee selectWaiter;
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
            selectTable = (Table)TablesLB.SelectedItem;
        }

        private void WaiterLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectWaiter = (Employee)WaiterLb.SelectedItem;
        }

        private void PositionLsb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectPosition = (Position)PositionLsb.SelectedItem;
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow addPosition = new AddPositionWindow();

            if (addPosition.ShowDialog() == true)
            {
                PositionLsb.ItemsSource = App.context.Position.ToList();
            }
        }

        private void AddTableBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTableWindow addTable = new AddTableWindow();

            if (addTable.ShowDialog() == true)
            {
                TablesLB.ItemsSource = App.context.Table.ToList();
            }
        }

        private void EditPositionsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PositionLsb.SelectedItem == null)
            {
                MessageBox.Show("Позиция не выбрана!");
            }
            else
            {
                AddPositionWindow addPosition = new AddPositionWindow(PositionLsb.SelectedItem as Position);
                if (addPosition.ShowDialog() == true)
                {

                }
            }
        }

        private void EditWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WaiterLb.SelectedItem == null)
            {
                MessageBox.Show("Официант не выбран!");
            }
            else
            {
                AddWaiterWindow addWaiter = new AddWaiterWindow(WaiterLb.SelectedItem as Employee);
                if (addWaiter.ShowDialog() == true)
                {

                }
            }
        }

        private void EditTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TablesLB.SelectedItem == null)
            {
                MessageBox.Show("Стол не выбран!");
            }
            else
            {
                AddTableWindow addTable = new AddTableWindow(TablesLB.SelectedItem as Table);
                if (addTable.ShowDialog() == true)
                {

                }
            }
        }

        private void DeleteTableBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.Table.Remove(selectTable);

            App.context.SaveChanges();

            TablesLB.ItemsSource = App.context.Table.ToList();
        }

        private void DeleteWaiterBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.Employee.Remove(selectWaiter);

            App.context.SaveChanges();

            WaiterLb.ItemsSource = App.context.Employee.Where(w => w.RoleId == 1).ToList();
        }

        private void DeletePositionsBtn_Click(object sender, RoutedEventArgs e)
        {
            App.context.Position.Remove(selectPosition);

            App.context.SaveChanges();

            PositionLsb.ItemsSource = App.context.Position.ToList();
        }

        private void AddWaiter_Click(object sender, RoutedEventArgs e)
        {

            AddWaiterWindow addWaiter = new AddWaiterWindow();

            if (addWaiter.ShowDialog() == true)
            {
                WaiterLb.ItemsSource = App.context.Employee.Where(w => w.RoleId == 1).ToList();
            }
        }
    }
}
