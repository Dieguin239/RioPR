namespace ProyectoRJ.Models
{
    public class Reporte
    {
        public int IdReporte { get; set; } // Clave primaria
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public string Prioridad { get; set; }
    }
}
