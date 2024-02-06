using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ListarTareasViewModel
{
    private List<TareaViewModel> tareasVM;

    public ListarTareasViewModel(List<Tarea> tareas)
    {
        tareasVM = new List<TareaViewModel>();

        foreach (var tar in tareas)
        {
            TareaViewModel tarea = new TareaViewModel(tar);
            tareasVM.Add(tarea);
        }
    }

    public List<TareaViewModel> TareasVM { get => tareasVM; set => tareasVM = value; }
}