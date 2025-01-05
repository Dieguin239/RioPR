namespace ProyectoRJ.Models
{
    public class RelacionIngenierosEmpresas
    {
        public int IdRelacion { get; set; } // Clave primaria
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
    }
}
