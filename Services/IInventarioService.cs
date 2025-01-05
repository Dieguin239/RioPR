using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventarioService
{
    Task<List<Inventario>> GetInventarios();
    Task<Inventario> GetInventarioById(int id);
    Task CreateInventario(Inventario inventario);
    Task UpdateInventario(Inventario inventario);
    Task DeleteInventario(int id);
}
