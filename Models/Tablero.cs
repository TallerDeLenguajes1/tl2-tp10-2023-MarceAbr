namespace tl2_tp10_2023_MarceAbr.Models
{
    public class Tablero
    {
        private int id;
        private int idUsuarioPropietario;
        private string? nombre;
        private string? descripcion;

        public Tablero(){}
        public Tablero(int idUsuarioPropietario, string nombre, string descripcion)
        {
            this.idUsuarioPropietario = idUsuarioPropietario;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public int IdUsuario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
    }
}