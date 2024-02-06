using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class TableroViewModel
{
    private int id;
    private int idUsuarioPropietario;
    private string? nombre;
    private string? descripcion;

    public TableroViewModel(){}

    public TableroViewModel(Tablero tab)
    {
        this.id = tab.Id;
        this.idUsuarioPropietario = tab.IdUsuario;
        this.nombre = tab.Nombre;
        this.descripcion = tab.Descripcion;
    }

    public int Id { get => id; set => id = value; }
    public int IdUsuario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
}