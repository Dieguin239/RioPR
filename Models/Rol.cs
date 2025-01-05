namespace ProyectoRJ.Models
{
    public class Rol
    {
        public int IdRol { get; set; } // Clave primaria
        public string NombreRol { get; set; }
        
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
