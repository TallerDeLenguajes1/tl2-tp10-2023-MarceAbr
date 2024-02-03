using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_MarceAbr.Repositorios;
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
    
    [HttpGet]
    public ActionResult<List<Usuario>> ListarUsuarios()
    {
        List<Usuario> usuarios = usuarioRepository.ListarUsuarios();
        if (usuarios != null)
        {
            return View(usuarios);
        } else {
            return NotFound();
        }
    }

    [HttpGet]
    public ActionResult<Usuario> AltaUsuario()
    {
        return View(new Usuario());
    }

    [HttpPost]
    public ActionResult<Usuario> CrearUsuario(Usuario usu)
    {
        usuarioRepository.CrearUsuario(usu);
        return RedirectToAction("ListarUsuarios");
    }

    [HttpPut]
    public ActionResult<Usuario> ModificarUsuario(int idUsu, Usuario usu) 
    {
        usuarioRepository.ModificarUsuario(idUsu, usu);
        return Ok(usu);
    }

    [HttpDelete]
    public ActionResult<Tarea> EliminarUsuario(int idUsu) 
    {
        usuarioRepository.EliminarUsuario(idUsu);
        return Ok();
    }
}