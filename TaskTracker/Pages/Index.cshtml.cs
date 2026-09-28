using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker.Pages;

public class IndexModel : PageModel
{
    private readonly TaskService _taskService;

    public IndexModel(TaskService taskService)
    {
        _taskService = taskService;
    }

    public List<TaskItem> Tasks { get; private set; } = [];

    [BindProperty]
    public string NewTaskTitle { get; set; } = string.Empty;

    public void OnGet()
    {
        LoadTasks();
    }

    public IActionResult OnPostAdd()
    {
        if (!string.IsNullOrWhiteSpace(NewTaskTitle))
        {
            _taskService.Add(NewTaskTitle.Trim());
        }

        return RedirectToPage();
    }

    public IActionResult OnPostToggle(int id)
    {
        _taskService.ToggleCompleted(id);

        return RedirectToPage();
    }

    public IActionResult OnPostDelete(int id)
    {
        _taskService.Delete(id);

        return RedirectToPage();
    }

    private void LoadTasks()
    {
        Tasks = _taskService.GetAll();
    }
}
