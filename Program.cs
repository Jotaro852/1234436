using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=my_host;Username=my_user;Password=my_password;Database=my_database";
        UserService userService = new UserService(connectionString);

        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.Write("Choose an option: ");
        int option = int.Parse(Console.ReadLine());

        if (option == 1)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            userService.Register(username, password);
            Console.WriteLine("Registration successful!");
        }
        else if (option == 2)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            if (userService.Login(username, password))
            {
                Console.WriteLine("Login successful!");
                // Здесь можно добавить логику для работы с задачами
            }
            else
            {
                Console.WriteLine("Login failed!");
            }
        }
    }
}