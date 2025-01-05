using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class SolicitudController : Controller
{
    private readonly ISolicitudService _solicitudService;
    private readonly IEmpresaService _empresaService;
    private readonly IUsuarioService _usuarioService;

    public SolicitudController(ISolicitudService solicitudService, IEmpresaService empresaService, IUsuarioService usuarioService)
    {
        _solicitudService = solicitudService;
        _empresaService = empresaService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var solicitudes = await _solicitudService.GetSolicitudes();
        return View(solicitudes);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Solicitud solicitud)
    {
        if (ModelState.IsValid)
        {
            await _solicitudService.CreateSolicitud(solicitud);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(solicitud);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudById(id);
        if (solicitud == null)
        {
            return NotFound();
        }
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(solicitud);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Solicitud solicitud)
    {
        if (id != solicitud.IdSolicitud)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _solicitudService.UpdateSolicitud(solicitud);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Empresas = await _empresaService.GetEmpresas();
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(solicitud);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var solicitud = await _solicitudService.GetSolicitudById(id);
        if (solicitud == null)
        {
            return NotFound();
        }
        return View(solicitud);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _solicitudService.DeleteSolicitud(id);
        return RedirectToAction(nameof(Index));
    }
}
