using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class MantenimientosController : Controller
{
    private readonly IMantenimientoService _mantenimientoService;
    private readonly IUsuarioService _usuarioService;

    public MantenimientosController(IMantenimientoService mantenimientoService, IUsuarioService usuarioService)
    {
        _mantenimientoService = mantenimientoService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var mantenimientos = await _mantenimientoService.GetMantenimientos();
        return View(mantenimientos);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Mantenimiento mantenimiento)
    {
        if (ModelState.IsValid)
        {
            await _mantenimientoService.CreateMantenimiento(mantenimiento);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(mantenimiento);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var mantenimiento = await _mantenimientoService.GetMantenimientoById(id);
        if (mantenimiento == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(mantenimiento);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Mantenimiento mantenimiento)
    {
        if (id != mantenimiento.IdMantenimiento)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _mantenimientoService.UpdateMantenimiento(mantenimiento);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(mantenimiento);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var mantenimiento = await _mantenimientoService.GetMantenimientoById(id);
        if (mantenimiento == null)
        {
            return NotFound();
        }
        return View(mantenimiento);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _mantenimientoService.DeleteMantenimiento(id);
        return RedirectToAction(nameof(Index));
    }
}
