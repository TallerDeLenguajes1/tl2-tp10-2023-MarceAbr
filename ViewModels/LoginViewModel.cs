using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp10_2023_MarceAbr.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo requerido.")]
        [Display(Name = "Nombre de Usuario")] 
        public string? NombreDeUsuario { get; set; }        


        [Required(ErrorMessage = "Campo requerido.")]
        [PasswordPropertyText]
        [Display(Name = "Contraseña")]
        public string? Contrasena { get; set; } 
    }
}