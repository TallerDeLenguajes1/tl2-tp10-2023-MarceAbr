namespace tl2_tp09_2023_MarceAbr.Models
{
    public class Tablero
    {
        private int id;
        private int idUsuarioPropietario;
        private string? nombre;
        private string? descripcion;

        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
    }
}