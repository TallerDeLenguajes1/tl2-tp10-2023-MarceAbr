using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

public class CrearTableroViewModel
{
    private int idUsuarioPropietario;
    private string? nombre;
    private string? descripcion;

    public CrearTableroViewModel(){}

    public CrearTableroViewModel(Tablero tablero)
    {
        this.idUsuarioPropietario = tablero.IdUsuario;
        this.nombre = tablero.Nombre;
        this.descripcion = tablero.Descripcion;
    }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Id Usuario Propietario")]
    public int IdUsuario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Nombre")]
    public string? Nombre { get => nombre; set => nombre = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Descripcion")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}