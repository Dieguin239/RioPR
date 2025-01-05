using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReporteService
{
    Task<List<Reporte>> GetReportes();
    Task<Reporte> GetReporteById(int id);
    Task CreateReporte(Reporte reporte);
    Task UpdateReporte(Reporte reporte);
    Task DeleteReporte(int id);
}
