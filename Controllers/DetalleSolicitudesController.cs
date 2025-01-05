using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class DetalleSolicitudesController : Controller
{
    private readonly IDetalleSolicitudService _detalleSolicitudService;
    private readonly ISolicitudService _solicitudService;
    private readonly IInventarioService _inventarioService;

    public DetalleSolicitudesController(IDetalleSolicitudService detalleSolicitudService, ISolicitudService solicitudService, IInventarioService inventarioService)
    {
        _detalleSolicitudService = detalleSolicitudService;
        _solicitudService = solicitudService;
        _inventarioService = inventarioService;
    }

    public async Task<IActionResult> Index()
    {
        var detalles = await _detalleSolicitudService.GetDetalles();
        return View(detalles);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Solicitudes = await _solicitudService.GetSolicitudes();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DetalleSolicitud detalle)
    {
        if (ModelState.IsValid)
        {
            await _detalleSolicitudService.CreateDetalle(detalle);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Solicitudes = await _solicitudService.GetSolicitudes();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(detalle);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var detalle = await _detalleSolicitudService.GetDetalleById(id);
        if (detalle == null)
        {
            return NotFound();
        }
        ViewBag.Solicitudes = await _solicitudService.GetSolicitudes();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(detalle);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, DetalleSolicitud detalle)
    {
        if (id != detalle.IdDetalle)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _detalleSolicitudService.UpdateDetalle(detalle);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Solicitudes = await _solicitudService.GetSolicitudes();
        ViewBag.Articulos = await _inventarioService.GetInventarios();
        return View(detalle);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var detalle = await _detalleSolicitudService.GetDetalleById(id);
        if (detalle == null)
        {
            return NotFound();
        }
        return View(detalle);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _detalleSolicitudService.DeleteDetalle(id);
        return RedirectToAction(nameof(Index));
    }
}
