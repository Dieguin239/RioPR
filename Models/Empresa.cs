namespace ProyectoRJ.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; } // Clave primaria
        public string NombreEmpresa { get; set; }

        public ICollection<Solicitud> Solicitudes { get; set; }
        public ICollection<RelacionIngenierosEmpresas>RelacionesIngenierosEmpresas { get; set; }
    }
}
