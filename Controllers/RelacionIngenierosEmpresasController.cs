using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class RelacionIngenierosEmpresasController : Controller
{
    private readonly IRelacionIngenierosEmpresasService _relacionService;
    private readonly IUsuarioService _usuarioService;
    private readonly IEmpresaService _empresaService;

    public RelacionIngenierosEmpresasController(IRelacionIngenierosEmpresasService relacionService, IUsuarioService usuarioService, IEmpresaService empresaService)
    {
        _relacionService = relacionService;
        _usuarioService = usuarioService;
        _empresaService = empresaService;
    }

    public async Task<IActionResult> Index()
    {
        var relaciones = await _relacionService.GetRelaciones();
        return View(relaciones);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(RelacionIngenierosEmpresas relacion)
    {
        if (ModelState.IsValid)
        {
            await _relacionService.CreateRelacion(relacion);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        return View(relacion);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var relacion = await _relacionService.GetRelacionById(id);
        if (relacion == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        return View(relacion);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, RelacionIngenierosEmpresas relacion)
    {
        if (id != relacion.IdRelacion)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _relacionService.UpdateRelacion(relacion);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        return View(relacion);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var relacion = await _relacionService.GetRelacionById(id);
        if (relacion == null)
        {
            return NotFound();
        }
        return View(relacion);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _relacionService.DeleteRelacion(id);
        return RedirectToAction(nameof(Index));
    }
}
