using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class EmpresasController : Controller
{
    private readonly IEmpresaService _empresaService;

    public EmpresasController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    public async Task<IActionResult> Index()
    {
        var empresas = await _empresaService.GetEmpresas();
        return View(empresas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Empresa empresa)
    {
        if (ModelState.IsValid)
        {
            await _empresaService.CreateEmpresa(empresa);
            return RedirectToAction(nameof(Index));
        }
        return View(empresa);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var empresa = await _empresaService.GetEmpresaById(id);
        if (empresa == null)
        {
            return NotFound();
        }
        return View(empresa);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Empresa empresa)
    {
        if (id != empresa.IdEmpresa)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _empresaService.UpdateEmpresa(empresa);
            return RedirectToAction(nameof(Index));
        }
        return View(empresa);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var empresa = await _empresaService.GetEmpresaById(id);
        if (empresa == null)
        {
            return NotFound();
        }
        return View(empresa);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _empresaService.DeleteEmpresa(id);
        return RedirectToAction(nameof(Index));
    }
}
