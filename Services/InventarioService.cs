using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InventarioService : IInventarioService
{
    private readonly ApplicationDbContext _context;

    public InventarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Inventario>> GetInventarios()
    {
        return await _context.Inventarios.Include(i => i.Usuario).ToListAsync();
    }

    public async Task<Inventario> GetInventarioById(int id)
    {
        return await _context.Inventarios.FindAsync(id);
    }

    public async Task CreateInventario(Inventario inventario)
    {
        _context.Inventarios.Add(inventario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateInventario(Inventario inventario)
    {
        _context.Inventarios.Update(inventario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInventario(int id)
    {
        var inventario = await _context.Inventarios.FindAsync(id);
        if (inventario != null)
        {
            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();
        }
    }
}
