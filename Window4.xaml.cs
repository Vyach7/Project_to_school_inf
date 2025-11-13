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
    public partial class Window4 : Window
    {
        private UserManager _userManager = new UserManager();

        public Window4()
        {
            InitializeComponent();
        }

        // ДОБАВЬТЕ ЭТИ МЕТОДЫ ДЛЯ ОБРАБОТКИ ИЗМЕНЕНИЯ ТЕКСТА:

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Обработчик изменения текста в LoginTextBox
            // Можно оставить пустым
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Обработчик изменения текста в PasswordTextBox
            // Можно оставить пустым
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveNewUser();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Код для кнопки "Вернуться"
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void SaveNewUser()
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text))
            {
                MessageBox.Show("Введите логин!", "Ошибка");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка");
                return;
            }

            string login = LoginTextBox.Text.Trim();

            if (_userManager.UserExists(login))
            {
                MessageBox.Show($"Пользователь с логином '{login}' уже существует!", "Ошибка");
                return;
            }

            User newUser = new User
            {
                Login = login,
                Password = PasswordTextBox.Text
            };

            _userManager.SaveUser(newUser);
            MessageBox.Show($"Пользователь {newUser.Login} успешно сохранен!", "Успех");

            LoginTextBox.Clear();
            PasswordTextBox.Clear();
        }
    }
}