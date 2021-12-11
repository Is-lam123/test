namespace ConsoleApp3
{

    public class User
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public string GetInfo()
        {
            if
            (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Name) &&
            !string.IsNullOrEmpty(Password))
            {
                return $"ID: {ID}, Имя: {Name}, Логин: {Username}, Пароль: {Password}";
            }
            else
            {
                return "Нет данных";
            }
        }
    }
}