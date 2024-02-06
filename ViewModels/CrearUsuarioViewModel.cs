using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

public class CrearUsuarioViewModel
{
    private string? nombreDeUsuario;
    private string? contrasena;
    private Rol rol;

    public CrearUsuarioViewModel(){}

    public CrearUsuarioViewModel(Usuario usuarioNuevo)
    {
        this.nombreDeUsuario = usuarioNuevo.NombreDeUsuario;
        this.contrasena = usuarioNuevo.Contrasena;
        this.rol = usuarioNuevo.Rol;
    }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Nombre de Usuario")]
    public string? NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [MaxLength(16, ErrorMessage = "Maximo 16 caracteres")]
    [Display(Name = "Contraseña")][PasswordPropertyText]
    public string? Contrasena { get => contrasena; set => contrasena = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Rol")]
    public Rol Rol { get => rol; set => rol = value; }
}