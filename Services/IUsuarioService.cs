using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUsuarioService
{
    Task<List<Usuario>> GetUsuarios();
    Task<Usuario> GetUsuarioById(int id);
    Task CreateUsuario(Usuario usuario);
    Task UpdateUsuario(Usuario usuario);
    Task DeleteUsuario(int id);
}
