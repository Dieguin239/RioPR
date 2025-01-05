using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRolService
{
    Task<List<Rol>> GetRoles();
    Task<Rol> GetRolById(int id);
    Task CreateRol(Rol rol);
    Task UpdateRol(Rol rol);
    Task DeleteRol(int id);
}
