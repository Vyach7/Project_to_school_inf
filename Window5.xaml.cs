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
    public partial class Window5 : Window
    {
        private UserManager _userManager = new UserManager();

        public Window5()
        {
            InitializeComponent();
            LoadUsers(); // Загружаем пользователей при запуске окна
        }

        // Загрузка пользователей в таблицу
        private void LoadUsers()
        {
            try
            {
                var allUsers = new List<User>();
                List<string> userLogins = _userManager.GetAllUsers();

                foreach (string login in userLogins)
                {
                    User? user = _userManager.LoadUser(login);
                    if (user != null)
                        allUsers.Add(user);
                }

                UsersDataGrid.ItemsSource = allUsers;

                // Обновляем заголовок окна с количеством пользователей
                this.Title = $"Управление пользователями ({allUsers.Count} пользователей)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Можно добавить логику при выборе пользователя
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelectedUser();
        }

        // Удаление выбранного пользователя
        private void DeleteSelectedUser()
        {
            User? selectedUser = UsersDataGrid.SelectedItem as User;

            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя для удаления!", "Предупреждение",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Подтверждение удаления
            MessageBoxResult result = MessageBox.Show(
                $"Вы уверены, что хотите удалить пользователя '{selectedUser.Login}'?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    bool success = _userManager.DeleteUser(selectedUser.Login);

                    if (success)
                    {
                        MessageBox.Show($"Пользователь '{selectedUser.Login}' успешно удален!", "Успех");
                        LoadUsers(); // Обновляем список после удаления
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить пользователя", "Ошибка");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}