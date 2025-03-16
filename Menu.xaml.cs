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
using Lavka62.Tablee;

namespace Lavka62
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }
        private void BaceWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close(); // Закрывает текущее окно
        }

        private void Flowers_Click(object sender, RoutedEventArgs e)
        {
            BDFlowers bDFlowers = new BDFlowers();
            bDFlowers.Show();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            BDOrders bDOrders = new BDOrders();
            bDOrders.Show();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            BDClient bDClient = new BDClient();
            bDClient.Show();
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (RoleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedRole = selectedItem.Content.ToString();

                if (selectedRole == "База данных о клиентах")
                {
                    // Открываем базу данных клиентов
                    BDClient bDClient = new BDClient();
                    bDClient.Show();
                }
                else if (selectedRole == "База данных о работниках")
                {
                    // Логика для открытия базы данных работников
                    BDPersonal bDPersonal = new BDPersonal();
                    bDPersonal.Show();
                }
                else if (selectedRole == "База данных о поставщиках")
                {
                    // Логика для открытия базы данных поставщиков
                    BDProviders bDProviders = new BDProviders();
                    bDProviders.Show();
                }
            }
        }
    }
}
