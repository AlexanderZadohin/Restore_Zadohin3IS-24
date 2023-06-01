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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        public PaymentWindow()
        {
            InitializeComponent();


            ToPayTbl.Text = $"{App.selectedCheque.TotalCost}";
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCheque.IsClosed = true;
            App.selectedCheque.Table.IsFree = true;

            App.context.SaveChanges();

            DialogResult = true;
            MessageBox.Show("Заказ умпешно оплачен!");


            Close();
        }

        private void BankCard_GotFocus(object sender, RoutedEventArgs e)
        {
            BankCard.Text = ToPayTbl.Text;
        }

        private void BankCard_LostFocus(object sender, RoutedEventArgs e)
        {
            BankCard.Clear();
        }

        private string GetChange()
        {
            if (CashTb.Text != string.Empty)
            {
                decimal chequeCash = App.selectedCheque.TotalCost;
                decimal clientCash = decimal.Parse(CashTb.Text);
                return $"Сдача: {(clientCash - chequeCash)} ₽";
            }
            return "0";
        }

        private void CashTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeTbl.Text = GetChange();
        }


        private void TelephoneNumCheck_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TelephoneNumCheck.Text.Length == 4)
            {
                var guest = App.context.Guest.FirstOrDefault(n => n.TelephoneNumber == TelephoneNumCheck.Text);
                if (guest.Discont == 5)
                {
                    Discont5.IsChecked = true;
                }
                if (guest.Discont == 10)
                {
                    Discont10.IsChecked = true;
                }
                if (guest.Discont == 15)
                {
                    Discont15.IsChecked = true;
                }
            }
            if (TelephoneNumCheck.Text.Length > 4)
            {
                MessageBox.Show("Такой номер недопустим");
                ToPayTbl.Text = $"{App.selectedCheque.TotalCost}";
            }
        }

        private void TelephoneNumCheck_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TelephoneNumCheck.Text == "")
            {
                Discont5.IsChecked = false;
                Discont10.IsChecked = false;
                Discont15.IsChecked = false;
                ToPayTbl.Text = $"{App.selectedCheque.TotalCost}";
            }
        }

        private void Discont5_Checked(object sender, RoutedEventArgs e)
        {
            ToPayTbl.Text = $"{(double)App.selectedCheque.TotalCost * 0.95}";
        }

        private void Discont10_Checked(object sender, RoutedEventArgs e)
        {

            ToPayTbl.Text = $"{(double)App.selectedCheque.TotalCost * 0.9}";
        }

        private void Discont15_Checked(object sender, RoutedEventArgs e)
        {

            ToPayTbl.Text = $"{(double)App.selectedCheque.TotalCost * 0.85}";
        }
    }
}
