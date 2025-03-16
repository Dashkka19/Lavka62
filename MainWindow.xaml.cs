using System;
using System.Collections.Generic;
using System.Data;
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
using Lavka62.Add;
using Lavka62.Edit;
using Lavka62.Tablee;

namespace Lavka62
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Проверить_Click(object sender, RoutedEventArgs e)
        {
            string name = NamePersonal.Text;
            string password = PasswordPersonal.Password;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var adapter = new Lavka62.Lavka62DataSetTableAdapters.PersonalsTableAdapter();
            var result = adapter.GetData(); // Получаем все данные из таблицы Personals

            // Проверьте, какое имя столбца правильно
            DataRow[] foundRows = result.Select($"[Name] = '{name}'"); // Используйте правильное имя столбца

            if (foundRows.Length == 0)
            {
                // Если имя пользователя не найдено
                MessageBox.Show("Ошибка: Пользователь не существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // Проверяем пароль
                string storedPassword = foundRows[0]["Password"].ToString(); // Предполагается, что у вас есть колонка Password

                if (storedPassword != password)
                {
                    // Если пароль не совпадает
                    MessageBox.Show("Ошибка: Пароль неверен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Если данные совпадают, выводим сообщение о успешной аутентификации
                    MessageBox.Show($"Добро пожаловать, {name}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Очистка полей ввода
                    NamePersonal.Text = string.Empty;
                    PasswordPersonal.Password = string.Empty;

                    Menu menu = new Menu();
                    menu.Show();
                    this.Close();
                }
            }
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает текущее окно
        }

        private void Забыли_Пароль_Click(object sender, RoutedEventArgs e)
        {
            EditPersonal editPersonal = new EditPersonal();
            editPersonal.Show();
        }

        private void Добавить_Click(object sender, RoutedEventArgs e)
        {
            AddPersonal addPersonal = new AddPersonal();
            addPersonal.Show();
        }
    }
}
