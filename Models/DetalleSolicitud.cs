namespace ProyectoRJ.Models
{
    public class DetalleSolicitud
    {
        public int IdDetalle { get; set; } // Clave primaria
        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }
        public int IdArticulo { get; set; }
        public Inventario Articulo { get; set; }
        public int Cantidad { get; set; }
    }
}
