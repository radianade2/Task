using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningWebAgit.Models;
using PlanningWebAgit.Services;

namespace PlanningWebAgit.Controllers;

public class HomeController : Controller
{
    private readonly PemerataanProduksi _pemerataanProduksi;
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, PemerataanProduksi pemerataanProduksi, AppDbContext context) {
        _logger = logger;
        _pemerataanProduksi = pemerataanProduksi;
        _context = context;
    }

    public IActionResult Index() {
        var rencanaList = _context.RencanaModel.OrderByDescending(r => r.TanggalProduksi).ToList();
        return View(rencanaList);
    }

    [HttpPost]
    public IActionResult Ratakan(int senin, int selasa, int rabu, int kamis, int jumat, int sabtu, int minggu) {
        int[] arrayAsli = new int[] { senin, selasa, rabu, kamis, jumat, sabtu, minggu };
        int[] arrayHasil = _pemerataanProduksi.Pemerataan(arrayAsli);
        var rencanaModel = new RencanaModel {
            SeninAsli = arrayAsli[0],
            SelasaAsli = arrayAsli[1],
            RabuAsli = arrayAsli[2],
            KamisAsli = arrayAsli[3],
            JumatAsli = arrayAsli[4],
            SabtuAsli = arrayAsli[5],
            MingguAsli = arrayAsli[6],

            SeninHasil = arrayHasil[0],
            SelasaHasil = arrayHasil[1],
            RabuHasil = arrayHasil[2],
            KamisHasil = arrayHasil[3],
            JumatHasil = arrayHasil[4],
            SabtuHasil = arrayHasil[5],
            MingguHasil = arrayHasil[6],

            TanggalProduksi = DateTime.Now
        };
        _context.RencanaModel.Add(rencanaModel);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
