namespace tl2_tp10_2023_MarceAbr.Models
{
    public enum Estado
    {
        Ideas,
        ToDo,
        Doing,
        Review,
        Done
    } 
    public class Tarea
    {
        private int id;
        private int idTablero;
        private string? nombre;
        private string? descripcion;
        private string? color;
        private Estado estadoTarea;
        private int idUsuarioAsignado;

        public Tarea()
        {
        }

        public Tarea(int idTablero, string nombre, string descripcion, string color, int idUsuarioAsignado, Estado est)
        {
            this.idTablero = idTablero;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.color = color;
            this.idUsuarioAsignado = idUsuarioAsignado;
            this.estadoTarea = est;
        }

        public int Id { get => id; set => id = value; }
        public int IdTablero { get => idTablero; set => idTablero = value; }
        public string? Nombre {get => nombre; set => nombre = value;}
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public string? Color { get => color; set => color = value; }
        public Estado EstadoTarea { get => estadoTarea; set => estadoTarea = value; }
        public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
    }
}