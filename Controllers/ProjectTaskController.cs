using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_cherevan.Models;

namespace wt_lab4_4mvc_cherevan.Controllers;

public class ProjectTaskController : Controller
{
    // Статический список — хранится в памяти, живёт всё время работы приложения
    private static readonly List<ProjectTask> Tasks = new()
    {
        new ProjectTask
        {
            Id = 1,
            Title = "Разработать главную страницу",
            Project = "Интернет-магазин",
            Assignee = "Иванов И.И.",
            Priority = "High",
            DueDate = new DateTime(2026, 11, 15),
            IsCompleted = false
        },
        new ProjectTask
        {
            Id = 2,
            Title = "Настроить базу данных PostgreSQL",
            Project = "CRM-система",
            Assignee = "Петров П.П.",
            Priority = "Medium",
            DueDate = new DateTime(2026, 11, 20),
            IsCompleted = true
        },
        new ProjectTask
        {
            Id = 3,
            Title = "Реализовать авторизацию пользователей",
            Project = "Личный кабинет",
            Assignee = "Сидорова А.В.",
            Priority = "High",
            DueDate = new DateTime(2026, 12, 01),
            IsCompleted = false
        },
        new ProjectTask
        {
            Id = 4,
            Title = "Написать unit-тесты для API",
            Project = "Мобильное приложение",
            Assignee = "Кузнецов Д.С.",
            Priority = "Low",
            DueDate = new DateTime(2026, 11, 30),
            IsCompleted = false
        },
        new ProjectTask
        {
            Id = 5,
            Title = "Настроить CI/CD в GitHub Actions",
            Project = "DevOps-инфраструктура",
            Assignee = "Морозова Е.А.",
            Priority = "Medium",
            DueDate = new DateTime(2026, 12, 10),
            IsCompleted = true
        },
        new ProjectTask
        {
            Id = 6,
            Title = "Провести код-ревью модуля оплаты",
            Project = "Интернет-магазин",
            Assignee = "Иванов И.И.",
            Priority = "High",
            DueDate = new DateTime(2026, 12, 05),
            IsCompleted = false
        }
    };

    // GET: /ProjectTask
    public IActionResult Index()
    {
        return View(Tasks);
    }

    // GET: /ProjectTask/Cards
    public IActionResult Cards()
    {
        return View(Tasks);
    }

    // GET: /ProjectTask/Details/5
    public IActionResult Details(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        return View(task);
    }

    // GET: /ProjectTask/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /ProjectTask/Create
    [HttpPost]
    public IActionResult Create(ProjectTask task)
    {
        if (!ModelState.IsValid)
            return View(task);

        task.Id = Tasks.Any() ? Tasks.Max(t => t.Id) + 1 : 1;
        Tasks.Add(task);

        return RedirectToAction("Index");
    }

    // POST: /ProjectTask/Delete/5
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
            Tasks.Remove(task);

        return RedirectToAction("Index");
    }
}