using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InformeMecanicoService : IInformeMecanicoService
{
    private readonly ApplicationDbContext _context;

    public InformeMecanicoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<InformeMecanico>> GetInformes()
    {
        return await _context.InformesMecanicos.Include(i => i.Usuario).ToListAsync();
    }

    public async Task<InformeMecanico> GetInformeById(int id)
    {
        return await _context.InformesMecanicos.FindAsync(id);
    }

    public async Task CreateInforme(InformeMecanico informe)
    {
        _context.InformesMecanicos.Add(informe);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateInforme(InformeMecanico informe)
    {
        _context.InformesMecanicos.Update(informe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInforme(int id)
    {
        var informe = await _context.InformesMecanicos.FindAsync(id);
        if (informe != null)
        {
            _context.InformesMecanicos.Remove(informe);
            await _context.SaveChangesAsync();
        }
    }
}
