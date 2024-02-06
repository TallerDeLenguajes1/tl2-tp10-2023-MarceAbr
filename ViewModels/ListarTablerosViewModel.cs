using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ListarTablerosViewModel
{
    private List<TableroViewModel> tablerosVM;

    public ListarTablerosViewModel(List<Tablero> tableros)
    {
        tablerosVM = new List<TableroViewModel>();

        foreach (var tab in tableros)
        {
            TableroViewModel tableroNuevo = new TableroViewModel(tab);
            tablerosVM.Add(tableroNuevo);
        }
    }

    public List<TableroViewModel> TablerosVM { get => tablerosVM; set => tablerosVM = value; }
}