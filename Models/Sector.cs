namespace ProyectoRJ.Models
{
    public class Sector
    {
        public int IdSector { get; set; } // Clave primaria
        public string NombreSector { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
