using _01_ServiceLifeTimes.Services;
using Microsoft.AspNetCore.Mvc;

namespace _01_ServiceLifeTimes.Controllers;

public class HomeController : Controller
{
    private readonly TransientService _transient;
    private readonly ScopedService _scoped;
    private readonly SingletonService _singleton;

    public HomeController(TransientService transient, ScopedService scoped, SingletonService singleton)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    public IActionResult Index()
    {
        var instance = new InstanceService();
        return View(instance);
    }

    public IActionResult Transient()
    {
        return View(_transient);
    }

    public IActionResult Scoped()
    {
        return View(_scoped);
    }

    public IActionResult Singleton()
    {
        return View(_singleton);
    }
}
