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
    /// Логика взаимодействия для CreateChequePage.xaml
    /// </summary>
    public partial class CreateChequePage : Page
    {
        // Итоговая цена
        decimal totalCost;
        // Промежутчный список для фильтрации
        List<Category> categories = new List<Category>();

        public CreateChequePage()
        {
            InitializeComponent();

            TotalCostTB.Text = GetTotalCost();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PositionLsb.ItemsSource = App.context.Position.ToList();

            TableTbl.DataContext = App.selectedTable;

            //TableTbl.Text = App.selectedTable.Title;

            DateTbl.Text = "Открыт: " + DateTime.Now.ToString();

            categories = App.context.Category.ToList();

            categories.Insert(0, new Category() { Title = "Все категории" });

            CategoryCmb.ItemsSource = categories;
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryCmb.SelectedIndex != 0)
            {
                PositionLsb.ItemsSource = App.context.Position.Where(p => p.Category.CategoryId == CategoryCmb.SelectedIndex).ToList();
            }
            else
            {
                PositionLsb.ItemsSource = App.context.Position.ToList();
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTb.Text != string.Empty)
            {
                PositionLsb.ItemsSource = App.context.Position.Where(p => p.Title.Contains(SearchTb.Text)).ToList();
            }
            else
            {
                PositionLsb.ItemsSource = App.context.Position.ToList();
            }
        }

        private void PositionsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PositionsLv.Items.Remove(PositionsLv.SelectedItem as Position);

            TotalCostTB.Text = GetTotalCost();
        }

        private void PositionLsb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedPosition = PositionLsb.SelectedItem as Position;

            if (PositionLsb.SelectedItem != null)
            {
                PositionsLv.Items.Add(App.selectedPosition);

                TotalCostTB.Text = GetTotalCost();

                PositionLsb.SelectedIndex = -1;
            }

            //PositionsLv.Items.Add(PositionLsb.SelectedItem as Position);
            //₽
        }

        private string GetTotalCost()
        {
            totalCost = 0;
            foreach (Position position in PositionsLv.Items)
            {
                totalCost += position.Cost;
            }

            return $"К оплате {totalCost} ₽";
        }

        private string GenerationChequeTittle()
        {
            DateTime dateDateTime = DateTime.Now;
            return $"Чек №{dateDateTime.Day}{dateDateTime.Month}{dateDateTime.Year}-{dateDateTime.Hour}{dateDateTime.Minute}";
            

        }

        private void CreateCheacueBtn_Click(object sender, RoutedEventArgs e)
        {
            //В какую таблицу добавить чек
            //Свойства таблицы гужно заполнить
            Cheque newCheque = new Cheque
            //инициализаторы
            {
                Title = GenerationChequeTittle(),
                TotalCost = totalCost,
                IsClosed = false,
                OpeningDate = DateTime.Now,
                WaiterId = App.enteredWaiter.WaiterId,
                TableId = App.selectedTable.TableId,
            };
            //Добавить объект
            App.context.Cheque.Add(newCheque);
            //Сохранить 
            App.context.SaveChanges();

            MessageBox.Show("Чек успешно добавлен!");
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow addPosition = new AddPositionWindow();
            
            if (addPosition.ShowDialog() == true)
            {
                PositionLsb.ItemsSource = App.context.Position.ToList();
            }
        }

        private void NewPositionsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
