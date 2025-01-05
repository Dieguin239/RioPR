using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISolicitudService
{
    Task<List<Solicitud>> GetSolicitudes();
    Task<Solicitud> GetSolicitudById(int id);
    Task CreateSolicitud(Solicitud solicitud);
    Task UpdateSolicitud(Solicitud solicitud);
    Task DeleteSolicitud(int id);
}
