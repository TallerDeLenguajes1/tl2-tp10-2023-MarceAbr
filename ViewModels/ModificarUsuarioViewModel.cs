using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ModificarUsuarioViewModel
{
    private int id;
    private string? nombreDeUsuario;
    private string? contrasena;
    private Rol rol;

    public ModificarUsuarioViewModel(){}

    public ModificarUsuarioViewModel(Usuario usu)
    {
        id = usu.Id;
        nombreDeUsuario = usu.NombreDeUsuario;
        contrasena = usu.Contrasena;
        rol = usu.Rol;
    }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    [Display(Name = "Id")]
    public int Id { get => id; set => id = value; }


    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Nombre de Usuario")]
    public string? NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Contraseña")]
    public string? Contrasena { get => contrasena; set => contrasena = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Rol")]
    public Rol Rol { get => rol; set => rol = value; }
}