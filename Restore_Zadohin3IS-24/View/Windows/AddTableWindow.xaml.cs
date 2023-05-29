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
using System.Windows.Shapes;

namespace Restore_Zadohin3IS_24.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTableWindow.xaml
    /// </summary>
    public partial class AddTableWindow : Window
    {
        bool isEdit = false;
        public AddTableWindow()
        {
            InitializeComponent();

            isEdit = false;
        }

        public AddTableWindow(Table selectedTable)
        {
            InitializeComponent();

            DataContext = selectedTable;

            isEdit = true;
        }

        private void AddTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if(isEdit == true)
            {
                AddTableBtn.Content = "Изменить";

                App.context.SaveChanges();

                MessageBox.Show("Стол успешно изменена!");

                DialogResult = true;
            }
            else
            {
                AddTableBtn.Content = "Добавить";
                Table newTable = new Table
                {
                    Title = NameOfTableTB.Text,
                    NumberOfVisitors = int.Parse(NumOfVisitorsTB.Text),
                    Description = DescriptionTB.Text,
                    IsFree = true
                };
                App.context.Table.Add(newTable);
                App.context.SaveChanges();
                MessageBox.Show("Стол добавлен!", "Потверждение добавления");
                DialogResult = true;
            }
            
        }
    }
}
