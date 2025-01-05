using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class UsuariosController : Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly ISectorService _sectorService;

    public UsuariosController(IUsuarioService usuarioService, ISectorService sectorService)
    {
        _usuarioService = usuarioService;
        _sectorService = sectorService;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioService.GetUsuarios();
        return View(usuarios);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Sectores = await _sectorService.GetSectores();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            await _usuarioService.CreateUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Sectores = await _sectorService.GetSectores();
        return View(usuario);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var usuario = await _usuarioService.GetUsuarioById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        ViewBag.Sectores = await _sectorService.GetSectores();
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Usuario usuario)
    {
        if (id != usuario.IdUsuario)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _usuarioService.UpdateUsuario(usuario);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Sectores = await _sectorService.GetSectores();
        return View(usuario);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.GetUsuarioById(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _usuarioService.DeleteUsuario(id);
        return RedirectToAction(nameof(Index));
    }
}
