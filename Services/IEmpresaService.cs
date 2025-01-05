using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEmpresaService
{
    Task<List<Empresa>> GetEmpresas();
    Task<Empresa> GetEmpresaById(int id);
    Task CreateEmpresa(Empresa empresa);
    Task UpdateEmpresa(Empresa empresa);
    Task DeleteEmpresa(int id);
}
