namespace tl2_tp10_2023_MarceAbr.Models
{
    public enum Rol
    {
        Administrador = 0,
        Operador = 1
    }
    public class Usuario
    {
        private int id;
        private string? nombreDeUsuario;
        private Rol rol;
        private string? contrasena;

        public int Id { get => id; set => id = value; }
        public string? NombreDeUsuario { get => nombreDeUsuario; set => nombreDeUsuario = value; }
        public Rol Rol { get => rol; set => rol = value; }
        public string? Contrasena { get => contrasena; set => contrasena = value; }
    }
}