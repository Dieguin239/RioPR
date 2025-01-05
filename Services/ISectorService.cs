using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISectorService
{
    Task<List<Sector>> GetSectores();
    Task<Sector> GetSectorById(int id);
    Task CreateSector(Sector sector);
    Task UpdateSector(Sector sector);
    Task DeleteSector(int id);
}
