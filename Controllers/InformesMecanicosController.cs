using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class InformesMecanicosController : Controller
{
    private readonly IInformeMecanicoService _informeMecanicoService;
    private readonly IUsuarioService _usuarioService;

    public InformesMecanicosController(IInformeMecanicoService informeMecanicoService, IUsuarioService usuarioService)
    {
        _informeMecanicoService = informeMecanicoService;
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var informes = await _informeMecanicoService.GetInformes();
        return View(informes);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(InformeMecanico informe)
    {
        if (ModelState.IsValid)
        {
            await _informeMecanicoService.CreateInforme(informe);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(informe);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var informe = await _informeMecanicoService.GetInformeById(id);
        if (informe == null)
        {
            return NotFound();
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(informe);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, InformeMecanico informe)
    {
        if (id != informe.IdInforme)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _informeMecanicoService.UpdateInforme(informe);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Usuarios = await _usuarioService.GetUsuarios();
        return View(informe);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var informe = await _informeMecanicoService.GetInformeById(id);
        if (informe == null)
        {
            return NotFound();
        }
        return View(informe);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _informeMecanicoService.DeleteInforme(id);
        return RedirectToAction(nameof(Index));
    }
}
