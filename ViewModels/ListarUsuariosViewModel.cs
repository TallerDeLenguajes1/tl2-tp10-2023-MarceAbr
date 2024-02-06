using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using tl2_tp10_2023_MarceAbr.Models;

namespace tl2_tp10_2023_MarceAbr.ViewModels;

public class ListarUsuariosViewModel
{
    private List<UsuarioViewModel> usuariosVM;

    public ListarUsuariosViewModel(List<Usuario> usuarios)
    {
        usuariosVM = new List<UsuarioViewModel>();

        foreach (var usuario in usuarios)
        {
            UsuarioViewModel usuarioNuevo = new UsuarioViewModel(usuario);
            UsuariosVM.Add(usuarioNuevo);
        }
    }

    public List<UsuarioViewModel> UsuariosVM { get => usuariosVM; set => usuariosVM = value; }
}