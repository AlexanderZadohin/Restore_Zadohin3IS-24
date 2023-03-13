using Restore_Zadohin3IS_24.Model;
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
    /// Логика взаимодействия для ChequePage.xaml
    /// </summary>
    public partial class ChequePage : Page
    {
        //private Table _selectedTable;
        //private Waiter _enteredWaiter;
        //private ChequePage _selectedCheque;

        public ChequePage(/*Waiter enteredWaiter*/)
        {
            InitializeComponent();

            //_enteredWaiter = enteredWaiter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TablesLB.ItemsSource = App.context.Table.ToList();
        }

        private void TablesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedTable = TablesLB.SelectedItem as Table;

            NavigationService.Navigate(new CreateChequePage());
        }

        //private void TablesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _selectedTable = TablesLB.SelectedItem as Table;

        //    if (_selectedTable.IsFree)
        //    {
        //        NavigationService.Navigate(new CreateChequePage(_selectedTable, _enteredWaiter));
        //    }
        //    else
        //    {
        //        MessageBox.Show("Стол занят. Используйте меню\"Открытые чеки\" для его изминения. ");
        //    }
        //}
    }
}
