using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_MarceAbr.Models;
using tl2_tp10_2023_MarceAbr.Repositorios;
using tl2_tp10_2023_MarceAbr.ViewModels;

namespace tl2_tp10_2023_juanigramajo.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioRepository usuarioRepository;
        private readonly ILogger<LoginController> _logger;


        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            usuarioRepository = new UsuarioRepository();
        }


         public IActionResult Index()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            List<Usuario> usuarios = usuarioRepository.ListarUsuarios();
            Usuario usuarioLoggeado = usuarios.FirstOrDefault(u => u.NombreDeUsuario == usuario.NombreDeUsuario && u.Contrasena == usuario.Contrasena);

            if (usuarioLoggeado == null)
            {
                return RedirectToAction("Error");
            } else
            {
                loggearUsuario(usuarioLoggeado);
                return RedirectToRoute(new { controller = "Home", action = "Index"});
            }
        }

        private void loggearUsuario(Usuario usuario)
        {
            HttpContext.Session.SetString("Id", usuario.Id.ToString());
            HttpContext.Session.SetString("NombreDeUsuario", usuario.NombreDeUsuario);
            HttpContext.Session.SetString("Rol", usuario.Rol.ToString());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}