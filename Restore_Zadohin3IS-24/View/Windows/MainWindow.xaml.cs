using Restore_Zadohin3IS_24.Model;
using Restore_Zadohin3IS_24.View.Pages;
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
using static Restore_Zadohin3IS_24.App;

namespace Restore_Zadohin3IS_24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Employee employee)
        {
            App.enteredEmployee = employee;
            InitializeComponent();
            if (employee == App.enteredEmployee)
            {
                WaiterTbl.Text = employee.Name;
                MainFrm.Navigate(new ChequePage(App.enteredEmployee));
                ShiftAccounting newAccount = new ShiftAccounting()
                {
                    EmployeeId = employee.WaiterId,
                    StartDate = 
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrm.CanGoBack)
            {
                MainFrm.GoBack();
            }
        }

        private void ExitProfileMi_Click(object sender, RoutedEventArgs e)
        {
            AuthorizathionWindow authorizathionWindow = new AuthorizathionWindow();
            Close();
            authorizathionWindow.ShowDialog();
            
        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddDiscontCardMi_Click(object sender, RoutedEventArgs e)
        {
            AddGuestDiscontCard addGuestDiscontCard = new AddGuestDiscontCard();
            addGuestDiscontCard.ShowDialog();
        }
    }
}
