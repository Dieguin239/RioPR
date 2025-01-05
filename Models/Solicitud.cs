namespace ProyectoRJ.Models
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; } // Clave primaria
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }

        public ICollection<DetalleSolicitud> DetallesSolicitudes { get; set; }
    }
}
