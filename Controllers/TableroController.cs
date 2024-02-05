using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_MarceAbr.Repositorios;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.Controllers;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tableroRepository;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
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
    public IActionResult ListarTableros()
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});

        string rolUsuario = HttpContext.Session.GetString("Rol");

        if (isAdmin())
        {    
            List<Tablero> tableros = tableroRepository.ListarTableros();
            if (tableros != null)
            {
                ViewBag.Rol = rolUsuario;
                return View(tableros);
            } else {
                return BadRequest();
            }
        } else {
            var idUser = HttpContext.Session.GetString("Id");
            var tableros = tableroRepository.ListarTableroPorUsuario(Convert.ToInt32(idUser));
            if (tableros != null)
            {
                ViewBag.Rol = rolUsuario;
                return View(tableros);
            }
            else
            {
                return BadRequest();
            }
        }
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTableros");
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult AltaTablero(Tablero tablero)
    {
        if(!ModelState.IsValid) return RedirectToAction("CrearTablero");
        tableroRepository.CrearTablero(tablero);
        return RedirectToAction("ListarTableros");
    }

    [HttpGet]
    public IActionResult ModificarTablero(int idTablero)
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTableros");
        return View(tableroRepository.MostrarTableroPorId(idTablero));
    }

    [HttpPost]
    public IActionResult EditarTablero(Tablero tablero)
    {
        if(!ModelState.IsValid) return RedirectToAction("EditarTablero");
        tableroRepository.ModificarTablero(tablero);
        return RedirectToAction("ListarTableros");
    }

    [HttpGet]
    public IActionResult EliminarTablero(int idTablero) 
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarTableros");
        return View(tableroRepository.MostrarTableroPorId(idTablero));
    }

    [HttpPost]
    public IActionResult EliminarTab(Tablero tablero) 
    {
        if(!ModelState.IsValid) return RedirectToAction("EliminarTablero");
        tableroRepository.EliminarTablero(tablero.Id);
        return RedirectToAction("ListarTableros");
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