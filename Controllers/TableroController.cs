using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_MarceAbr.Models;
using tl2_tp09_2023_MarceAbr.Repositorios;
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

    [HttpGet("Listar_Tableros")]
    public ActionResult<List<Tablero>> ListarTableros()
    {
        List<Tablero> tableros = tableroRepository.ListarTableros();
        if (tableros != null)
        {
            return Ok(tableros);
        } else {
            return NotFound();
        }
    }

    [HttpPost("Crear_Tablero")]
    public ActionResult<Tablero> CrearTablero(Tablero tablero)
    {
        tableroRepository.CrearTablero(tablero);
        return Ok(tablero);
    }

    [HttpPut("Modificar_Tablero")]
    public ActionResult<Tablero> ModificarTablero(int idTab, Tablero tablero) 
    {
        tableroRepository.ModificarTablero(idTab, tablero);
        return Ok(tablero);
    }

    [HttpDelete("Eliminar_Tablero")]
    public ActionResult<Tablero> EliminarTablero(int idTab) 
    {
        tableroRepository.EliminarTablero(idTab);
        return Ok();
    }
}