using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_MarceAbr.Repositorios;
using tl2_tp10_2023_MarceAbr.Models;
using tl2_tp10_2023_MarceAbr.ViewModels;

namespace tl2_tp10_2023_MarceAbr.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository _usuarioRepository)
    {
        _logger = logger;
        usuarioRepository = _usuarioRepository;
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
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});

        string rolUsuario = HttpContext.Session.GetString("Rol");

        ListarUsuariosViewModel usuarios = new ListarUsuariosViewModel(usuarioRepository.ListarUsuarios());
        if (usuarios != null)
        {
            ViewBag.Rol = rolUsuario;
            return View(usuarios);
        } else {
            return BadRequest();
        }
    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarUsuarios");
        return View(new CrearUsuarioViewModel());
    }

    [HttpPost]
    public IActionResult AltaUsuario(Usuario usu)
    {
        if(!ModelState.IsValid) return RedirectToAction("CrearUsuario");
        usuarioRepository.CrearUsuario(usu);
        return RedirectToAction("ListarUsuarios");
    }

    [HttpGet]
    public IActionResult ModificarUsuario(int idUsuario)
    {  
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarUsuarios");
        return View(new ModificarUsuarioViewModel(usuarioRepository.MostrarUsuario(idUsuario)));
    }

    [HttpPost]
    public IActionResult EditarUsuario(Usuario usu)
    {
        if(!ModelState.IsValid) return RedirectToAction("ModificarUsuario");
        usuarioRepository.ModificarUsuario(usu);
        return RedirectToAction("ListarUsuarios");
    }

    [HttpGet]
    public IActionResult EliminarUsuario(int idUsuario)
    {
        if(!isLogged()) return RedirectToRoute(new { controller = "Login", action = "Index"});
        if(!isAdmin()) return RedirectToAction("ListarUsuarios");
        return View(usuarioRepository.MostrarUsuario(idUsuario));
    }

    [HttpPost]
    public IActionResult EliminarUsu(Usuario usu)
    {
        if(!ModelState.IsValid) return RedirectToAction("EliminarUsuario");
        usuarioRepository.EliminarUsuario(usu.Id);
        return RedirectToAction("ListarUsuarios");
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