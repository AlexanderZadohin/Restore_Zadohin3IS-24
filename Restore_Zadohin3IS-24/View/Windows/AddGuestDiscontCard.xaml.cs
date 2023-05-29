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
    /// Логика взаимодействия для AddGuestDiscontCard.xaml
    /// </summary>
    public partial class AddGuestDiscontCard : Window
    {
        int DiscontProc;
        public AddGuestDiscontCard()
        {
            InitializeComponent();

        }
        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            GuestBtn.Content = "Добавить";
            Guest newGuest = new Guest
            {
                FIO = FIOTbl.Text,
                TelephoneNumber = NumberTbl.Text,
                Discont = DiscontProc
            };
            App.context.Guest.Add(newGuest);
            App.context.SaveChanges();
            MessageBox.Show("Гость добавлен!", "Потверждение добавления");
            DialogResult = true;
        }

        private void Discont5_Checked(object sender, RoutedEventArgs e)
        {
            DiscontProc = 5;
        }

        private void Discont10_Checked(object sender, RoutedEventArgs e)
        {
            DiscontProc = 10;
        }

        private void Discont15_Checked(object sender, RoutedEventArgs e)
        {
            DiscontProc = 15;
        }
    }
}
