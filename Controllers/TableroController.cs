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
        List<Tablero> tableros = tableroRepository.ListarTableros();
        if (tableros != null)
        {
            return View(tableros);
        } else {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult AltaTablero(Tablero tablero)
    {
        tableroRepository.CrearTablero(tablero);
        return RedirectToAction("ListarTableros");
    }

    [HttpGet]
    public IActionResult ModificarTablero(int idTablero)
    {
        return View(tableroRepository.MostrarTableroPorId(idTablero));
    }

    [HttpPost]
    public IActionResult EditarTablero(Tablero tablero) 
    {
        tableroRepository.ModificarTablero(tablero);
        return RedirectToAction("ListarTableros");
    }

    [HttpGet]
    public IActionResult EliminarTablero(int idTablero) 
    {
        return View(tableroRepository.MostrarTableroPorId(idTablero));
    }

    [HttpPost]
    public IActionResult EliminarTab(Tablero tablero) 
    {
        tableroRepository.EliminarTablero(tablero.Id);
        return RedirectToAction("ListarTableros");
    }
}