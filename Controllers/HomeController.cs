using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP6_MARASCH_TAGLIORETTI_WICNUDEL.Models;

namespace TP6_MARASCH_TAGLIORETTI_WICNUDEL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Deportes()
    {
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.Paises = BD.ListarPaises();
        return View();
    }

    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.Deporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.Deportistas = BD.ListarDeportistasPorDeporte(idDeporte);
        return View("DetalleDeporte");
    }

    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.Pais = BD.VerInfoPais(idPais);
        ViewBag.Deportistas = BD.ListarDeportistasPorPais(idPais);
        return View("DetallePais");
    }

    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.Deportista = BD.VerInfoDeportista(idDeportista);
        return View("DetalleDeportista");
    }

    public IActionResult AgregarDeportista()
    {
        ViewBag.Paises = BD.ListarPaises();
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    [HttpPost]
    public IActionResult GuardarDeportista(Deportistas dep)
    {
        BD.AgregarDeportista(dep);
        return RedirectToAction("Index");
    }

    public IActionResult EliminarDeportista(int idDeportista)
    {
        BD.EliminarDeportista(idDeportista);
        return RedirectToAction("Index");
    }

    public IActionResult Creditos()
    {
        return View();
    }
}
