using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_MarceAbr.Repositorios;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.Controllers;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Listartareas()
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        List<Tarea> tareas = tareaRepository.ListarTareas();
        if (tareas != null)
        {
            return View(tareas);
        } else {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTareas");
        return View(new Tarea());
    }

    [HttpPost]
    public IActionResult AltaTarea(Tarea tarea)
    {
        if(!ModelState.IsValid) return RedirectToAction("CrearTarea");
        tareaRepository.CrearTarea(tarea);
        return RedirectToAction("Listartareas");
    }

    [HttpGet]
    public IActionResult ModificarTarea(int idTarea) 
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTareas");
        return View(tareaRepository.MostrarTareaPorId(idTarea));
    }

    [HttpPost]
    public IActionResult EditarTarea(Tarea tarea) 
    {
        if(!ModelState.IsValid) return RedirectToAction("ModificarTarea");
        tareaRepository.ModificarTarea(tarea);
        return RedirectToAction("ListarTareas");
    }

    [HttpGet]
    public IActionResult EliminarTarea(int idTarea) 
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTareas");
        return View(tareaRepository.MostrarTareaPorId(idTarea));
    }
    
    [HttpPost]
    public IActionResult EliminarTar(Tarea tarea) 
    {
        if(!ModelState.IsValid) return RedirectToAction("EliminarTarea");
        tareaRepository.EliminarTarea(tarea.Id);
        return RedirectToAction("ListarTareas");
    }

    private bool isLogged()
    {
        if (HttpContext.Session.GetString("Id") != null)
        {
            return true;
        } else {
            return false;
        }
    }

    private bool isAdmin()
    {
        if (HttpContext.Session.GetString("Rol") == "Administrador")
        {
            return true;
        } else {
            return false;
        }
    }
}