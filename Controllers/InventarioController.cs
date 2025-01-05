using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class InventarioController : Controller
{
    private readonly IInventarioService _inventarioService;
    private readonly IUsuarioService _usuarioService;

    public InventarioController(IInventarioService inventarioService, IUsuarioService usuarioService)
    {
        _inventarioService = inventarioService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var inventarios = await _inventarioService.GetInventarios();
        return View(inventarios);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Inventario inventario)
    {
        if (ModelState.IsValid)
        {
            await _inventarioService.CreateInventario(inventario);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(inventario);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var inventario = await _inventarioService.GetInventarioById(id);
        if (inventario == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(inventario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Inventario inventario)
    {
        if (id != inventario.IdArticulo)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _inventarioService.UpdateInventario(inventario);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(inventario);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var inventario = await _inventarioService.GetInventarioById(id);
        if (inventario == null)
        {
            return NotFound();
        }
        return View(inventario);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _inventarioService.DeleteInventario(id);
        return RedirectToAction(nameof(Index));
    }
}
