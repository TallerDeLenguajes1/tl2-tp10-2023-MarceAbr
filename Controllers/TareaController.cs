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

    [HttpGet("Listar_Tareas")]
    public ActionResult<List<Tarea>> Listartareas()
    {
        List<Tarea> tareas = tareaRepository.ListarTareas();
        if (tareas != null)
        {
            return Ok(tareas);
        } else {
            return NotFound();
        }
    }

    [HttpPost("Crear_Tarea")]
    public ActionResult<Tarea> CrearTarea(int idTab, Tarea tarea)
    {
        tareaRepository.CrearTarea(idTab, tarea);
        return Ok(tarea);
    }

    [HttpPut("Modificar_Tarea")]
    public ActionResult<Tarea> ModificarTarea(int idTarea, Tarea tarea) 
    {
        tareaRepository.ModificarTarea(idTarea, tarea);
        return Ok(tarea);
    }

    [HttpDelete("Eliminar_Tarea")]
    public ActionResult<Tarea> EliminarTarea(int idTarea) 
    {
        tareaRepository.EliminarTarea(idTarea);
        return Ok();
    }
}