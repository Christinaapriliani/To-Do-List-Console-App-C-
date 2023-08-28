using System;
using System.IO;
using System.Collections.Generic;

class TaskManager {
    private List<string> tasks = new List<string>();

    public TaskManager() {
        LoadTasks();
    }

    private void LoadTasks() {
        if (File.Exists("tasks.txt")) {
            tasks = new List<string>(File.ReadAllLines("tasks.txt"));
        }
    }

    private void SaveTasks() {
        File.WriteAllLines("tasks.txt", tasks);
    }

    public void AddTask(string task) {
        tasks.Add(task);
        SaveTasks();
    }

    public void DeleteTask(int taskNumber) {
        if (taskNumber >= 1 && taskNumber <= tasks.Count) {
            tasks.RemoveAt(taskNumber - 1);
            SaveTasks();
        }
    }

    public void DisplayTasks() {
        for (int i = 0; i < tasks.Count; i++) {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    public void Start() {
        while (true) {
            Console.WriteLine("\nTodo List App\n");
            DisplayTasks();
            Console.WriteLine("\nWhat would you like to do? (add/delete/quit): ");
            string action = Console.ReadLine().ToLower();

            if (action == "add") {
                Console.WriteLine("Enter a new task: ");
                string newTask = Console.ReadLine();
                AddTask(newTask);
            } else if (action == "delete") {
                Console.WriteLine("Enter the task number to delete: ");
                int taskNumber = int.Parse(Console.ReadLine());
                DeleteTask(taskNumber);
            } else if (action == "quit") {
                break;
            } else {
                Console.WriteLine("Invalid action. Please choose add, delete, or quit.");
            }
        }
    }
}

class Program {
    static void Main(string[] args) {
        TaskManager taskManager = new TaskManager();
        taskManager.Start();
    }
}
