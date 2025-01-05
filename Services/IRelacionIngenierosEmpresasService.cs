using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRelacionIngenierosEmpresasService
{
    Task<List<RelacionIngenierosEmpresas>> GetRelaciones();
    Task<RelacionIngenierosEmpresas> GetRelacionById(int id);
    Task CreateRelacion(RelacionIngenierosEmpresas relacion);
    Task UpdateRelacion(RelacionIngenierosEmpresas relacion);
    Task DeleteRelacion(int id);
}
