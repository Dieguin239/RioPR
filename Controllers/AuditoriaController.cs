using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class AuditoriaController : Controller
{
    private readonly IAuditoriaService _auditoriaService;
    private readonly IUsuarioService _usuarioService;

    public AuditoriaController(IAuditoriaService auditoriaService, IUsuarioService usuarioService)
    {
        _auditoriaService = auditoriaService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var auditorias = await _auditoriaService.GetAuditorias();
        return View(auditorias);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Auditoria auditoria)
    {
        if (ModelState.IsValid)
        {
            await _auditoriaService.CreateAuditoria(auditoria);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(auditoria);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var auditoria = await _auditoriaService.GetAuditoriaById(id);
        if (auditoria == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(auditoria);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Auditoria auditoria)
    {
        if (id != auditoria.IdAuditoria)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _auditoriaService.UpdateAuditoria(auditoria);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(auditoria);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var auditoria = await _auditoriaService.GetAuditoriaById(id);
        if (auditoria == null)
        {
            return NotFound();
        }
        return View(auditoria);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _auditoriaService.DeleteAuditoria(id);
        return RedirectToAction(nameof(Index));
    }
}
