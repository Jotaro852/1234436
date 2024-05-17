int userId = // Получите ID пользователя из базы данных
    TaskService taskService = new TaskService(connectionString);

// Добавление задачи
taskService.AddTask(userId, "Задача 1", "Описание задачи 1", DateTime.Now.AddDays(1));

// Редактирование задачи
taskService.EditTask(1, "Новое название задачи", "Новое описание задачи", DateTime.Now.AddDays(2));

// Просмотр задач на сегодня
taskService.ViewTasks(userId, DateTime.Today, DateTime.Today.AddDays(1));

// Удаление задачи
taskService.DeleteTask(1);
// эту часть можно вставить в основной части программы, а можно использовать для отдельного класа taskService