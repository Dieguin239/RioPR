using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SolicitudService : ISolicitudService
{
    private readonly ApplicationDbContext _context;

    public SolicitudService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Solicitud>> GetSolicitudes()
    {
        return await _context.Solicitudes
            .Include(s => s.Empresa)
            .Include(s => s.Usuario)
            .ToListAsync();
    }

    public async Task<Solicitud> GetSolicitudById(int id)
    {
        return await _context.Solicitudes
            .Include(s => s.Empresa)
            .Include(s => s.Usuario)
            .FirstOrDefaultAsync(s => s.IdSolicitud == id);
    }

    public async Task CreateSolicitud(Solicitud solicitud)
    {
        _context.Solicitudes.Add(solicitud);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSolicitud(Solicitud solicitud)
    {
        _context.Solicitudes.Update(solicitud);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSolicitud(int id)
    {
        var solicitud = await _context.Solicitudes.FindAsync(id);
        if (solicitud != null)
        {
            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();
        }
    }
}
