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
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ListarUsuarios()
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
    public IActionResult CrearUsuario()
    {
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult AltaUsuario(Usuario usu)
    {
        usuarioRepository.CrearUsuario(usu);
        return RedirectToAction("ListarUsuarios");
    }

    [HttpGet]
    public IActionResult ModificarUsuario(int idUsuario)
    {  
        return View(usuarioRepository.MostrarUsuario(idUsuario));
    }

    [HttpPost]
    public IActionResult EditarUsuario(Usuario usu)
    {
        usuarioRepository.ModificarUsuario(usu);
        return RedirectToAction("ListarUsuarios");
    }

    [HttpGet]
    public IActionResult EliminarUsuario(int idUsuario)
    {
        return View(usuarioRepository.MostrarUsuario(idUsuario));
    }

    [HttpPost]
    public IActionResult EliminarUsu(Usuario usu)
    {
        usuarioRepository.EliminarUsuario(usu.Id);
        return RedirectToAction("ListarUsuarios");
    }
}