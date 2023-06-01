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
    /// Логика взаимодействия для AncountWindow.xaml
    /// </summary>
    public partial class AncountWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        List<ShiftAccounting> shifts = new List<ShiftAccounting>();
        public AncountWindow()
        {
            InitializeComponent();

            ShiftLsv.ItemsSource = App.context.ShiftAccounting.ToList();
        }

        private void CategoryAccoutCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryAccoutCmb.SelectedIndex != 0)
            {

                ShiftLsv.ItemsSource = App.context.ShiftAccounting.Where(date => date.StartDate >= (DateTime)CategoryAccoutCmb.SelectedItem).ToList();
            }
            else
            {
                ShiftLsv.ItemsSource = App.context.ShiftAccounting.ToList();
            }
        }
        private void AllRevenueBtn_Click(object sender, RoutedEventArgs e)
        {
            var allRevenueWaiters = App.context.ShiftAccounting.ToList();
            MessageBox.Show($"Общая выручка составляет: {allRevenueWaiters.Sum(w => Convert.ToDecimal(w.Revenue))} ₽") ;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                ShiftLsv.ItemsSource = App.context.ShiftAccounting.Where(n => n.Name.Contains(SearchTb.Text)).ToList();
            }
            else
            {
                ShiftLsv.ItemsSource = App.context.ShiftAccounting.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            shifts = App.context.ShiftAccounting.ToList();
            employees = App.context.Employee.ToList();
            CategoryAccoutCmb.ItemsSource = shifts;
        }
    }
}
