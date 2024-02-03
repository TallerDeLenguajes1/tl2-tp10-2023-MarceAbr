using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_MarceAbr.Models;
using tl2_tp09_2023_MarceAbr.Repositorios;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpGet("Listar_Usuarios")]
    public ActionResult<List<Usuario>> ListarUsuarios()
    {
        List<Usuario> usuarios = usuarioRepository.ListarUsuarios();
        if (usuarios != null)
        {
            return Ok(usuarios);
        } else {
            return NotFound();
        }
    }

    [HttpPost("Crear_Usuario")]
    public ActionResult<Usuario> CrearUsuario(Usuario usu)
    {
        usuarioRepository.CrearUsuario(usu);
        return Ok(usu);
    }

    [HttpPut("Modificar_Usuario")]
    public ActionResult<Usuario> ModificarUsuario(int idUsu, Usuario usu) 
    {
        usuarioRepository.ModificarUsuario(idUsu, usu);
        return Ok(usu);
    }

    [HttpDelete("Eliminar_Usuario")]
    public ActionResult<Tarea> EliminarUsuario(int idUsu) 
    {
        usuarioRepository.EliminarUsuario(idUsu);
        return Ok();
    }
}