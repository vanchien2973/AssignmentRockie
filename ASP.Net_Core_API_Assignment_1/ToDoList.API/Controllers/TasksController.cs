using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers;

public class TasksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}