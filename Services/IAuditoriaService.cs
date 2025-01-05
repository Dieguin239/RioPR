using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAuditoriaService
{
    Task<List<Auditoria>> GetAuditorias();
    Task<Auditoria> GetAuditoriaById(int id);
    Task CreateAuditoria(Auditoria auditoria);
    Task UpdateAuditoria(Auditoria auditoria);
    Task DeleteAuditoria(int id);
}
