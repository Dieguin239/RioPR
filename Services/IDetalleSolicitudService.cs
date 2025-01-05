using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDetalleSolicitudService
{
    Task<List<DetalleSolicitud>> GetDetalles();
    Task<DetalleSolicitud> GetDetalleById(int id);
    Task CreateDetalle(DetalleSolicitud detalle);
    Task UpdateDetalle(DetalleSolicitud detalle);
    Task DeleteDetalle(int id);
}
