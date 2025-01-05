using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RelacionIngenierosEmpresasService : IRelacionIngenierosEmpresasService
{
    private readonly ApplicationDbContext _context;

    public RelacionIngenierosEmpresasService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RelacionIngenierosEmpresas>> GetRelaciones()
    {
        return await _context.RelacionesIngenierosEmpresas
            .Include(r => r.Usuario)
            .Include(r => r.Empresa)
            .ToListAsync();
    }

    public async Task<RelacionIngenierosEmpresas> GetRelacionById(int id)
    {
        return await _context.RelacionesIngenierosEmpresas
            .Include(r => r.Usuario)
            .Include(r => r.Empresa)
            .FirstOrDefaultAsync(r => r.IdRelacion == id);
    }

    public async Task CreateRelacion(RelacionIngenierosEmpresas relacion)
    {
        _context.RelacionesIngenierosEmpresas.Add(relacion);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRelacion(RelacionIngenierosEmpresas relacion)
    {
        _context.RelacionesIngenierosEmpresas.Update(relacion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRelacion(int id)
    {
        var relacion = await _context.RelacionesIngenierosEmpresas.FindAsync(id);
        if (relacion != null)
        {
            _context.RelacionesIngenierosEmpresas.Remove(relacion);
            await _context.SaveChangesAsync();
        }
    }
}
