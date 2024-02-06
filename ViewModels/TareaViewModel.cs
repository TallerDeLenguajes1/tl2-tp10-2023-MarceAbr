using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class TareaViewModel
{
    private int id;
    private int idTablero;
    private string? nombre;
    private string? descripcion;
    private string? color;
    private Estado estadoTarea;
    private int idUsuarioAsignado;

    public TareaViewModel(){}

    public TareaViewModel(Tarea tarea)
    {
        this.id = tarea.Id;
        this.idTablero = tarea.IdTablero;
        this.nombre = tarea.Nombre;
        this.color = tarea.Color;
        this.estadoTarea = tarea.EstadoTarea;
        this.idUsuarioAsignado = tarea.IdUsuarioAsignado;
    }

    public int Id { get => id; set => id = value; }
    public int IdTablero { get => idTablero; set => idTablero = value; }
    public string? Nombre {get => nombre; set => nombre = value;}
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public Estado EstadoTarea { get => estadoTarea; set => estadoTarea = value; }
    public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
}