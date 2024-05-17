/* в этом примере не реализованы методы Register и Login в классе UserService,
 а также не реализованы методы AddTask, EditTask, DeleteTask и ViewTasks в классе TaskService.*/


using System;
using System.Security.Cryptography;
using Npgsql;

class Program
{
    static string connectionString = "Host=localhost;Username=postgres;Password=password;Database=todo_db";

    static void Main(string[] args)
    {
        UserService userService = new UserService(connectionString);
        TaskService taskService = new TaskService(connectionString);

        // Регистрация пользователя
        userService.Register("user1", "password1");

        // Авторизация пользователя
        int userId = userService.Login("user1", "password1");

        if (userId != -1)
        {
            // Добавление задачи
            taskService.AddTask(userId, "Задача 1", "Описание задачи 1", DateTime.Now.AddDays(1));

            // Редактирование задачи
            taskService.EditTask(1, "Новое название задачи", "Новое описание задачи", DateTime.Now.AddDays(2));

            // Просмотр задач на сегодня
            taskService.ViewTasks(userId, DateTime.Today, DateTime.Today.AddDays(1));

            // Удаление задачи
            taskService.DeleteTask(1);
        }
        else
        {
            Console.WriteLine("Неверный логин или пароль.");
        }
    }
}

public class UserService
{
    private readonly string _connectionString;

    public UserService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Register(string username, string password)
    {
        // Реализация регистрации пользователя
    }

    public int Login(string username, string password)
    {
        // Реализация авторизации пользователя
        return -1; // Заглушка, должен возвращать ID пользователя или -1 в случае ошибки
    }

    // Дополнительные методы для хеширования паролей и проверки их
}

public class TaskService
{
    private readonly string _connectionString;

    public TaskService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddTask(int userId, string title, string description, DateTime dueDate)
    {
        // Реализация добавления задачи
    }

    public void EditTask(int taskId, string title, string description, DateTime dueDate)
    {
        // Реализация редактирования задачи
    }

    public void DeleteTask(int taskId)
    {
        // Реализация удаления задачи
    }

    public void ViewTasks(int userId, DateTime? startDate = null, DateTime? endDate = null)
    {
        // Реализация просмотра задач
    }
}