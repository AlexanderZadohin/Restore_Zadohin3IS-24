using Microsoft.Win32;
using Restore_Zadohin3IS_24.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        List<Category> categories = new List<Category>();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public AddPositionWindow()
        {
            InitializeComponent();

            SelectCatecoryCmb.ItemsSource = categories;
            categories = App.context.Category.ToList();
        }

        private void SelectCatecoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            categories = App.context.Category.ToList();

            SelectCatecoryCmb.ItemsSource = categories;
        }

        private void AddPositionBtn_Click(object sender, RoutedEventArgs e)
        {
            Position newPosition = new Position
            {
                Title = NamePositionTB.Text,
                Cost = decimal.Parse(CostPositionTB.Text),
                CategoryId = SelectCatecoryCmb.SelectedIndex + 1,
                Photo = File.ReadAllBytes(openFileDialog.FileName)
            };
            App.context.Position.Add(newPosition);
            App.context.SaveChanges();
            MessageBox.Show("Позиция добавлена!","Потверждение добавления");
            DialogResult = true;
        }

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.ShowDialog();
        }
    }
}
