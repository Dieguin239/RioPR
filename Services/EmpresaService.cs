using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EmpresaService : IEmpresaService
{
    private readonly ApplicationDbContext _context;

    public EmpresaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empresa>> GetEmpresas()
    {
        return await _context.Empresas.ToListAsync();
    }

    public async Task<Empresa> GetEmpresaById(int id)
    {
        return await _context.Empresas.FindAsync(id);
    }

    public async Task CreateEmpresa(Empresa empresa)
    {
        _context.Empresas.Add(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmpresa(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmpresa(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa != null)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
