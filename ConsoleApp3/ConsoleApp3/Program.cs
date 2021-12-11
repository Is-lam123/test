using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp3
{


    internal class Program
    {
        internal static List<User> Users { get; set; }
        private static string Username { get; set; }
        private static string Password { get; set; }
        private static int Key { get; set; }
        private static int Action { get; set; }
        static void Main()
        {


            Users = new List<User>();

            void ListCommand()
            {
                Console.WriteLine("\n1. Добавить данные");
                Console.WriteLine("2. Редактировать данные");
                Console.WriteLine("3. Удалить данные");
                Console.WriteLine("4. Просмотр данных");
                Console.WriteLine("5. Поиск данных");
                Console.WriteLine("6. Выход из профиля");
                Console.WriteLine("7. Закрытие программы");
            }
            while (Key != 3)
            {
                Console.WriteLine("Регистрация (1) | Войти(2) | Пропусть (3)");
                Console.WriteLine("Введите команду: ", ConsoleColor.Yellow);
                Key = int.Parse(Console.ReadLine());
                if (Key == 1)
                {
                    Console.WriteLine("Авторизация");
                    Console.WriteLine("Логин: ", ConsoleColor.Blue);
                    Username = Console.ReadLine();
                    Console.WriteLine("Пароль: ", ConsoleColor.Blue);
                    Password = Console.ReadLine();

                    var authorizationQuery = Users.FirstOrDefault(item => item.Username == Username && item.Password == Password);
                    if (authorizationQuery != null)
                    {
                        Console.WriteLine("Авторизация прошла успешно!\n", ConsoleColor.Green);
                        while (Action != 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            ListCommand();
                            Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                Console.WriteLine("Введите команду: ", ConsoleColor.DarkBlue);

                                Action = int.Parse(Console.ReadLine());
                                switch (Action)
                                {
                                    case 1:

                                        Console.Write("Введите ID: ");
                                        int idEdit = int.Parse(Console.ReadLine());
                                        var editUser = Users.FirstOrDefault(item => item.ID == idEdit);
                                        if (editUser != null)
                                        {
                                            ActionUser(editUser);
                                        }
                                        else
                                        {

                                            Console.WriteLine("Ошибка!Нет данных!", ConsoleColor.Red);
                                        }
                                        break;
                                    case 2:
                                        Console.Write("Введите ID: ");
                                        int idRemove = int.Parse(Console.ReadLine());
                                        var removeUser = Users.FirstOrDefault(item => item.ID == idRemove);
                                        if (removeUser != null)
                                        {
                                            Users.Remove(removeUser);

                                            Console.WriteLine("Операция прошла успешно!", ConsoleColor.Green);
                                        }
                                        else
                                        {

                                            Console.WriteLine("Ошибка!Нет данных!", ConsoleColor.Red);
                                        }
                                        break;
                                    case 3:

                                        if (Users.Any())
                                        {
                                            foreach (var user in Users)
                                            {
                                                Console.WriteLine(user.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Console.WriteLine("Ошибка!Нет данных!", ConsoleColor.Red);
                                        }
                                        break;
                                    case 4:

                                        Console.Write("Введите данные: ");
                                        string search = Console.ReadLine();
                                        var searchUser = Users.Where(item => item.ID.ToString().Contains(search) || item.Name.Contains(search) ||
                                        item.Username.Contains(search) || item.Password.Contains(search)).ToList();
                                        if (searchUser.Any())
                                        {
                                            foreach (var item in searchUser)
                                            {
                                                Console.WriteLine(item.GetInfo());
                                            }
                                        }
                                        else
                                        {

                                            Console.WriteLine("Ошибка!Нет данных!", ConsoleColor.Red);
                                        }
                                        break;
                                    case 5:
                                        Process.GetCurrentProcess().Kill();
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка!Нет данных!\n", ConsoleColor.Red);
                    }
                }
            }
        }

        private static void ActionUser(User editUser)
        {
            throw new NotImplementedException();
        }
    }
}



      