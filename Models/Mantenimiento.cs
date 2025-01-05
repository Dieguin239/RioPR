namespace ProyectoRJ.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; } // Clave primaria
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
    }
}
