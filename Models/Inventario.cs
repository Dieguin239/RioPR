namespace ProyectoRJ.Models
{
    public class Inventario
    {
        public int IdArticulo { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public int CantidadDisponible { get; set; }
        public string Marca { get; set; }
        public decimal Peso { get; set; }
        public string Descripcion { get; set; }
        public string UbicacionUso { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Condicion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<SalidaInventario> SalidasInventario { get; set;}
        public ICollection<DetalleSolicitud> DetallesSolicitudes { get; set; }
    }
}
