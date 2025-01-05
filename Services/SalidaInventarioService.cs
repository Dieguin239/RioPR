using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SalidaInventarioService : ISalidaInventarioService
{
    private readonly ApplicationDbContext _context;

    public SalidaInventarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalidaInventario>> GetSalidas()
    {
        return await _context.SalidasInventario
            .Include(s => s.Articulo)
            .Include(s => s.Usuario)
            .ToListAsync();
    }

    public async Task<SalidaInventario> GetSalidaById(int id)
    {
        return await _context.SalidasInventario
            .Include(s => s.Articulo)
            .Include(s => s.Usuario)
            .FirstOrDefaultAsync(s => s.IdSalida == id);
    }

    public async Task CreateSalida(SalidaInventario salida)
    {
        _context.SalidasInventario.Add(salida);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSalida(SalidaInventario salida)
    {
        _context.SalidasInventario.Update(salida);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSalida(int id)
    {
        var salida = await _context.SalidasInventario.FindAsync(id);
        if (salida != null)
        {
            _context.SalidasInventario.Remove(salida);
            await _context.SaveChangesAsync();
        }
    }
}
