using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInformeMecanicoService
{
    Task<List<InformeMecanico>> GetInformes();
    Task<InformeMecanico> GetInformeById(int id);
    Task CreateInforme(InformeMecanico informe);
    Task UpdateInforme(InformeMecanico informe);
    Task DeleteInforme(int id);
}
