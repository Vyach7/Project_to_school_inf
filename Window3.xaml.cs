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

namespace project_to_school_inf
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private UserManager _userManager = new UserManager();

        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckLoginAndPassword();
        }

        private void CheckLoginAndPassword()
        {
            string login = Login.Text.Trim();
            string password = Parol.Text;

            // Проверяем, что поля не пустые
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                Login.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                Parol.Focus();
                return;
            }

            // Загружаем пользователя по логину
            User user = _userManager.LoadUser(login);

            if (user == null)
            {
                MessageBox.Show($"Пользователь с логином '{login}' не найден!\nЗарегистрируйтесь сначала.",
                              "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверяем пароль
            if (user.Password == password)
            {
                // Успешная авторизация
                MessageBox.Show($"Добро пожаловать, {login}!", "Успех",
                              MessageBoxButton.OK, MessageBoxImage.Information);

                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                Parol.Focus();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window4 window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // Обработчик изменения логина
        }

        private void Parol_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Обработчик изменения пароля
        }
    }
}
