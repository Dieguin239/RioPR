using Microsoft.AspNetCore.Mvc;
using ProyectoRJ.Models;
using System.Threading.Tasks;

public class SectoresController : Controller
{
    private readonly ISectorService _sectorService;

    public SectoresController(ISectorService sectorService)
    {
        _sectorService = sectorService;
    }

    public async Task<IActionResult> Index()
    {
        var sectores = await _sectorService.GetSectores();
        return View(sectores);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Sector sector)
    {
        if (ModelState.IsValid)
        {
            await _sectorService.CreateSector(sector);
            return RedirectToAction(nameof(Index));
        }
        return View(sector);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var sector = await _sectorService.GetSectorById(id);
        if (sector == null)
        {
            return NotFound();
        }
        return View(sector);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Sector sector)
    {
        if (id != sector.IdSector)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _sectorService.UpdateSector(sector);
            return RedirectToAction(nameof(Index));
        }
        return View(sector);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var sector = await _sectorService.GetSectorById(id);
        if (sector == null)
        {
            return NotFound();
        }
        return View(sector);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _sectorService.DeleteSector(id);
        return RedirectToAction(nameof(Index));
    }
}
