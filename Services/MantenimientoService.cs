using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MantenimientoService : IMantenimientoService
{
    private readonly ApplicationDbContext _context;

    public MantenimientoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Mantenimiento>> GetMantenimientos()
    {
        return await _context.Mantenimientos.Include(m => m.Usuario).ToListAsync();
    }

    public async Task<Mantenimiento> GetMantenimientoById(int id)
    {
        return await _context.Mantenimientos.FindAsync(id);
    }

    public async Task CreateMantenimiento(Mantenimiento mantenimiento)
    {
        _context.Mantenimientos.Add(mantenimiento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMantenimiento(Mantenimiento mantenimiento)
    {
        _context.Mantenimientos.Update(mantenimiento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMantenimiento(int id)
    {
        var mantenimiento = await _context.Mantenimientos.FindAsync(id);
        if (mantenimiento != null)
        {
            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();
        }
    }
}
