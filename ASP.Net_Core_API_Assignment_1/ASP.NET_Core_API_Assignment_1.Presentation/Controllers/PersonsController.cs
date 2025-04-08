using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_API_Assignment_1.Presentation.Controllers;

public class PersonsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}