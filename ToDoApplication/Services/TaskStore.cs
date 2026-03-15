using System.Collections.ObjectModel;
using ToDoApplication.Models;

namespace ToDoApplication.Services;

public static class TaskStore
{
    public static ObservableCollection<ToDoClass> Tasks { get; } = new ObservableCollection<ToDoClass>();
    public static ObservableCollection<ToDoClass> StarredTasks { get; set; } = new();
    public static ToDoClass ? SelectedTask { get; set; }

}
