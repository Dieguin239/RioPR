using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISalidaInventarioService
{
    Task<List<SalidaInventario>> GetSalidas();
    Task<SalidaInventario> GetSalidaById(int id);
    Task CreateSalida(SalidaInventario salida);
    Task UpdateSalida(SalidaInventario salida);
    Task DeleteSalida(int id);
}
