using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ModificarTareaViewModel
{
    private int id;
    private int idTablero;
    private string? nombre;
    private string? descripcion;
    private string? color;
    private Estado estadoTarea;
    private int idUsuarioAsignado;

    public ModificarTareaViewModel(){}

    public ModificarTareaViewModel(Tarea tarea)
    {
        this.id = tarea.Id;
        this.idTablero = tarea.IdTablero;
        this.nombre = tarea.Nombre;
        this.descripcion = tarea.Descripcion;
        this.color = tarea.Color;
        this.estadoTarea = tarea.EstadoTarea;
        this.idUsuarioAsignado = tarea.IdUsuarioAsignado;
    }

    [Required(ErrorMessage = "Este campo no puede estar vacio")]
    [Display(Name = "Id")]
    public int Id { get => id; set => id = value; }


    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Id Tablero")]
    public int IdTablero { get => idTablero; set => idTablero = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Nombre")]
    public string? Nombre {get => nombre; set => nombre = value;}

    [MaxLength(50, ErrorMessage = "La descripcion debe tener hasta 50 caracteres")]
    [Display(Name = "Descripcion")]
    public string? Descripcion { get => descripcion; set => descripcion = value; }

    [Display(Name = "Color")]
    public string? Color { get => color; set => color = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Estado Tarea")]
    public Estado EstadoTarea { get => estadoTarea; set => estadoTarea = value; }

    [Required(ErrorMessage = "Complete el campo")]
    [Display(Name = "Id Usuario Asignado")]
    public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
}