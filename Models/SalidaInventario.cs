namespace ProyectoRJ.Models
{
    public class SalidaInventario
    {
        public int IdSalida { get; set; } // Clave primaria
        public int IdArticulo { get; set; }
        public Inventario Articulo { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int CantidadSalida { get; set; }
        public DateTime FechaSalida { get; set; }
        public string EstadoUso { get; set; }
        public int CantidadUsada { get; set; }
    }
}
