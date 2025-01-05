using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMantenimientoService
{
    Task<List<Mantenimiento>> GetMantenimientos();
    Task<Mantenimiento> GetMantenimientoById(int id);
    Task CreateMantenimiento(Mantenimiento mantenimiento);
    Task UpdateMantenimiento(Mantenimiento mantenimiento);
    Task DeleteMantenimiento(int id);
}
