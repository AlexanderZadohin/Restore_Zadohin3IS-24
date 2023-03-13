using Restore_Zadohin3IS_24.Model;
using Restore_Zadohin3IS_24.View.Pages;
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

namespace Restore_Zadohin3IS_24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Waiter waiter)
        {
            App.enteredWaiter = waiter;
            InitializeComponent();
            WaiterTbl.Text = waiter.Name;
            MainFrm.Navigate(new ChequePage());
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrm.CanGoBack)
            {
                MainFrm.GoBack();
            }
        }
    }
}
