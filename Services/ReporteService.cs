using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReporteService : IReporteService
{
    private readonly ApplicationDbContext _context;

    public ReporteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reporte>> GetReportes()
    {
        return await _context.Reportes.Include(r => r.Usuario).ToListAsync();
    }

    public async Task<Reporte> GetReporteById(int id)
    {
        return await _context.Reportes.FindAsync(id);
    }

    public async Task CreateReporte(Reporte reporte)
    {
        _context.Reportes.Add(reporte);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReporte(Reporte reporte)
    {
        _context.Reportes.Update(reporte);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReporte(int id)
    {
        var reporte = await _context.Reportes.FindAsync(id);
        if (reporte != null)
        {
            _context.Reportes.Remove(reporte);
            await _context.SaveChangesAsync();
        }
    }
}
