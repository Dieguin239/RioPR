namespace ProyectoRJ.Models
{
    public class InformeMecanico
    {
        public int IdInforme { get; set; } // Clave primaria
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string TipoMantenimiento { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }

}
