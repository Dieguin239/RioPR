using Microsoft.EntityFrameworkCore;
using ProyectoRJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RolService : IRolService
{
    private readonly ApplicationDbContext _context;

    public RolService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rol>> GetRoles()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Rol> GetRolById(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task CreateRol(Rol rol)
    {
        _context.Roles.Add(rol);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRol(Rol rol)
    {
        _context.Roles.Update(rol);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRol(int id)
    {
        var rol = await _context.Roles.FindAsync(id);
        if (rol != null)
        {
            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
        }
    }
}
