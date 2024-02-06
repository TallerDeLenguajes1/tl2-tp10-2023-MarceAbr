using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ModificarTableroViewModel
{
    private int id;
    private int idUsuarioPropietario;
    private string? nombre;
    private string? descripcion;

    public ModificarTableroViewModel(){}

    public ModificarTableroViewModel(Tablero tab)
    {
        this.id = tab.Id;
        this.id = tab.IdUsuario;
        this.nombre = tab.Nombre;
        this.descripcion = tab.Descripcion;
    }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    [Display(Name = "Id")]
    public int Id { get => id; set => id = value; }

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