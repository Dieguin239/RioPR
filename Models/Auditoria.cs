namespace ProyectoRJ.Models
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; } // Clave primaria
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAccion { get; set; }
    }
}
