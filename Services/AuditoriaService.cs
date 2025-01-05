using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AuditoriaService : IAuditoriaService
{
    private readonly ApplicationDbContext _context;

    public AuditoriaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Auditoria>> GetAuditorias()
    {
        return await _context.Auditorias.Include(a => a.Usuario).ToListAsync();
    }

    public async Task<Auditoria> GetAuditoriaById(int id)
    {
        return await _context.Auditorias.FindAsync(id);
    }

    public async Task CreateAuditoria(Auditoria auditoria)
    {
        _context.Auditorias.Add(auditoria);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuditoria(Auditoria auditoria)
    {
        _context.Auditorias.Update(auditoria);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuditoria(int id)
    {
        var auditoria = await _context.Auditorias.FindAsync(id);
        if (auditoria != null)
        {
            _context.Auditorias.Remove(auditoria);
            await _context.SaveChangesAsync();
        }
    }
}
