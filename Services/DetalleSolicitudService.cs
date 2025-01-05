using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DetalleSolicitudService : IDetalleSolicitudService
{
    private readonly ApplicationDbContext _context;

    public DetalleSolicitudService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DetalleSolicitud>> GetDetalles()
    {
        return await _context.DetallesSolicitudes
            .Include(d => d.Solicitud)
            .Include(d => d.Articulo)
            .ToListAsync();
    }

    public async Task<DetalleSolicitud> GetDetalleById(int id)
    {
        return await _context.DetallesSolicitudes
            .Include(d => d.Solicitud)
            .Include(d => d.Articulo)
            .FirstOrDefaultAsync(d => d.IdDetalle == id);
    }

    public async Task CreateDetalle(DetalleSolicitud detalle)
    {
        _context.DetallesSolicitudes.Add(detalle);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDetalle(DetalleSolicitud detalle)
    {
        _context.DetallesSolicitudes.Update(detalle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDetalle(int id)
    {
        var detalle = await _context.DetallesSolicitudes.FindAsync(id);
        if (detalle != null)
        {
            _context.DetallesSolicitudes.Remove(detalle);
            await _context.SaveChangesAsync();
        }
    }
}
