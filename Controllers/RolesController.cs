using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class RolesController : Controller
{
    private readonly IRolService _rolService;

    public RolesController(IRolService rolService)
    {
        _rolService = rolService;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _rolService.GetRoles();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Rol rol)
    {
        if (ModelState.IsValid)
        {
            await _rolService.CreateRol(rol);
            return RedirectToAction(nameof(Index));
        }
        return View(rol);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var rol = await _rolService.GetRolById(id);
        if (rol == null)
        {
            return NotFound();
        }
        return View(rol);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Rol rol)
    {
        if (id != rol.IdRol)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _rolService.UpdateRol(rol);
            return RedirectToAction(nameof(Index));
        }
        return View(rol);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var rol = await _rolService.GetRolById(id);
        if (rol == null)
        {
            return NotFound();
        }
        return View(rol);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _rolService.DeleteRol(id);
        return RedirectToAction(nameof(Index));
    }
}
