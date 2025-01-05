using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class SalidaInventarioController : Controller
{
    private readonly ISalidaInventarioService _salidaInventarioService;
    private readonly IUsuarioService _usuarioService;
    private readonly IInventarioService _inventarioService;

    public SalidaInventarioController(ISalidaInventarioService salidaInventarioService, IUsuarioService usuarioService, IInventarioService inventarioService)
    {
        _salidaInventarioService = salidaInventarioService;
        _usuarioService = usuarioService;
        _inventarioService = inventarioService;
    }

    public async Task<IActionResult> Index()
    {
        var salidas = await _salidaInventarioService.GetSalidas();
        return View(salidas);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SalidaInventario salida)
    {
        if (ModelState.IsValid)
        {
            await _salidaInventarioService.CreateSalida(salida);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(salida);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var salida = await _salidaInventarioService.GetSalidaById(id);
        if (salida == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(salida);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, SalidaInventario salida)
    {
        if (id != salida.IdSalida)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _salidaInventarioService.UpdateSalida(salida);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(salida);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var salida = await _salidaInventarioService.GetSalidaById(id);
        if (salida == null)
        {
            return NotFound();
        }
        return View(salida);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _salidaInventarioService.DeleteSalida(id);
        return RedirectToAction(nameof(Index));
    }
}
