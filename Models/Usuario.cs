 namespace ProyectoRJ.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public int IdSector { get; set; }
        public Sector Sector { get; set; }

        public ICollection<Inventario> Inventarios { get; set; }
        public ICollection<SalidaInventario> SalidasInventario { get; set; }
        public ICollection<Solicitud> Solicitudes { get; set; }
        public ICollection<RelacionIngenierosEmpresas> RelacionesIngenierosEmpresas { get; set; }
        public ICollection<InformeMecanico> InformesMecanicos { get; set; }
        public ICollection<Mantenimiento> Mantenimientos { get; set; }
        public ICollection<Auditoria> Auditorias { get; set; }
        public ICollection<Reporte> Reportes { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }

}
