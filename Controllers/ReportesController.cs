using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class ReportesController : Controller
{
    private readonly IReporteService _reporteService;
    private readonly IUsuarioService _usuarioService;

    public ReportesController(IReporteService reporteService, IUsuarioService usuarioService)
    {
        _reporteService = reporteService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var reportes = await _reporteService.GetReportes();
        return View(reportes);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Reporte reporte)
    {
        if (ModelState.IsValid)
        {
            await _reporteService.CreateReporte(reporte);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(reporte);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var reporte = await _reporteService.GetReporteById(id);
        if (reporte == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(reporte);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Reporte reporte)
    {
        if (id != reporte.IdReporte)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _reporteService.UpdateReporte(reporte);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(reporte);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var reporte = await _reporteService.GetReporteById(id);
        if (reporte == null)
        {
            return NotFound();
        }
        return View(reporte);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _reporteService.DeleteReporte(id);
        return RedirectToAction(nameof(Index));
    }
}
