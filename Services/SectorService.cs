using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SectorService : ISectorService
{
    private readonly ApplicationDbContext _context;

    public SectorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sector>> GetSectores()
    {
        return await _context.Sectores.ToListAsync();
    }

    public async Task<Sector> GetSectorById(int id)
    {
        return await _context.Sectores.FindAsync(id);
    }

    public async Task CreateSector(Sector sector)
    {
        _context.Sectores.Add(sector);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSector(Sector sector)
    {
        _context.Sectores.Update(sector);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSector(int id)
    {
        var sector = await _context.Sectores.FindAsync(id);
        if (sector != null)
        {
            _context.Sectores.Remove(sector);
            await _context.SaveChangesAsync();
        }
    }
}
