using TaskTracker.Models;

namespace TaskTracker.Services;

public class TaskService
{
    private readonly List<TaskItem> _tasks =
    [
        new TaskItem
        {
            Id = 1,
            Title = "Learn C# classes",
            IsCompleted = false
        },
        new TaskItem
        {
            Id = 2,
            Title = "Create a GitHub Actions workflow",
            IsCompleted = false
        }
    ];

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public void Add(string title)
    {
        var nextId = _tasks.Count == 0
            ? 1
            : _tasks.Max(task => task.Id) + 1;

        _tasks.Add(new TaskItem
        {
            Id = nextId,
            Title = title,
            IsCompleted = false
        });
    }

    public void ToggleCompleted(int id)
    {
        var task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is not null)
        {
            task.IsCompleted = !task.IsCompleted;
        }
    }

    public void Delete(int id)
    {
        var task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task is not null)
        {
            _tasks.Remove(task);
        }
    }
}
