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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restore_Zadohin3IS_24.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditChequePage.xaml
    /// </summary>
    public partial class EditChequePage : Page
    {
        // Итоговая цена
        private decimal totalCost;

        private Position _selectedPosition;

        private List<Category> categories;
        private List<Position> positions;
        // Промежутчный список для фильтрации

        public EditChequePage()
        {
            InitializeComponent();

            totalCost = App.selectedCheque.TotalCost;
            TotalCostTB.Text = GetTotalCost(PositionsLsv);

            EarlierPositionLsv.ItemsSource = App.context.ChequePosition.Where(cp => cp.ChequeId == App.selectedCheque.ChequeId).ToList();


            PositionLsb.ItemsSource = App.context.Position.ToList();

            TableTbl.Text = App.selectedCheque.Table.Title;

            DateTbl.Text = $"Открыт: {App.selectedCheque.OpeningDate.ToString()}";

            categories = App.context.Category.ToList();

            categories.Insert(0, new Category() { Title = "Все категории" });

            CategoryCmb.ItemsSource = categories;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private string GetTotalCost(ListView positinsLv)
        {
            totalCost = App.selectedCheque.TotalCost;
            foreach (Position position in positinsLv.Items)
            {
                totalCost += position.Cost;
            }

            return $"К оплате {totalCost} ₽";
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            positions = App.context.Position.ToList();
            if (CategoryCmb.SelectedIndex != 0)
            {
                PositionLsb.ItemsSource = App.context.Position.Where(p => p.Category.CategoryId == CategoryCmb.SelectedIndex).ToList();
                PositionLsb.ItemsSource = positions;
            }
            else
            {
                PositionLsb.ItemsSource = positions;
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            positions = App.context.Position.ToList();
            if (SearchTb.Text != string.Empty)
            {
                if (SearchTb.Text != "Поиск по названию") 
                {
                    PositionLsb.ItemsSource = App.context.Position.Where(p => p.Title.Contains(SearchTb.Text)).ToList();
                    PositionLsb.ItemsSource = positions;
                }
            }
            else
            {
                PositionLsb.ItemsSource = positions;
            }
        }


        private void PositionLsb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedPosition = PositionLsb.SelectedItem as Position;

            if (_selectedPosition != null)
            {
                PositionsLsv.Items.Add(_selectedPosition);

                TotalCostTB.Text = GetTotalCost(PositionsLsv);

                PositionLsb.SelectedIndex = -1;
            }

            //PositionsLv.Items.Add(PositionLsb.SelectedItem as Position);
            //₽
        }
        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            PaymentWindow paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();

            if (paymentWindow.DialogResult == true) 
            {
                NavigationService.Navigate(new ChequePage(App.selectedCheque.Waiter));
            }
        }

        private void PositionsLsv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PositionsLsv.Items.Remove((sender as ListView).SelectedItem as Position);

            TotalCostTB.Text = GetTotalCost(PositionsLsv);
        }

        private void EarlierPositionLsv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditChequeBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCheque.TotalCost = totalCost;
            foreach (Position position in PositionsLsv.Items) 
            {
                ChequePosition chequePosition = new ChequePosition
                {
                    ChequeId = App.selectedCheque.ChequeId,
                    PositionId = position.PositionId,
                };
                App.context.ChequePosition.Add(chequePosition);
                App.context.SaveChanges();
            }
            MessageBox.Show("Новые позиции добавлены в чек!");
        }
    }
}
