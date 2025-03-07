using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploMVC_MAT.Models;
using EjemploMVC_MAT.Services;
using System.Threading.Tasks;

namespace EjemploMVC_MAT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CardService _cardService;

    public HomeController(ILogger<HomeController> logger, CardService cardService)
    {
        _logger = logger;
        _cardService = cardService;
    }

    // Método para la vista de la lista de cartas, con paginación
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var cards = await _cardService.GetBlueEyesCardsAsync(page, pageSize);
        ViewData["PageNumber"] = page;
        return View(cards);
    }

    public async Task<IActionResult> Details(int id)
    {
        var card = await _cardService.GetCardByIdAsync(id);
        if (card == null)
        {
            return NotFound();
        }
        return View(card);
    }
}

