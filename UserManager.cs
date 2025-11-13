using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace project_to_school_inf
{
    public class UserManager
    {
        private readonly string _usersFolder = "Users";

        public UserManager()
        {
            if (!Directory.Exists(_usersFolder))
                Directory.CreateDirectory(_usersFolder);
        }

        // Метод для удаления пользователя
        public bool DeleteUser(string login)
        {
            try
            {
                string filePath = Path.Combine(_usersFolder, $"{login}.json");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении пользователя: {ex.Message}", "Ошибка");
                return false;
            }
        }

        // Получение списка всех пользователей
        public List<string> GetAllUsers()
        {
            try
            {
                if (!Directory.Exists(_usersFolder))
                    return new List<string>();

                return new List<string>(
                    Directory.GetFiles(_usersFolder, "*.json")
                        .Select(file => Path.GetFileNameWithoutExtension(file))
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении списка пользователей: {ex.Message}", "Ошибка");
                return new List<string>();
            }
        }

        public User? LoadUser(string login)
        {
            try
            {
                string filePath = Path.Combine(_usersFolder, $"{login}.json");
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<User>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователя: {ex.Message}", "Ошибка");
            }
            return null;
        }

        public bool UserExists(string login)
        {
            string filePath = Path.Combine(_usersFolder, $"{login}.json");
            return File.Exists(filePath);
        }

        public void SaveUser(User user)
        {
            try
            {
                string filePath = Path.Combine(_usersFolder, $"{user.Login}.json");
                string json = JsonSerializer.Serialize(user,
                    new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении пользователя: {ex.Message}", "Ошибка");
            }
        }
    }
}