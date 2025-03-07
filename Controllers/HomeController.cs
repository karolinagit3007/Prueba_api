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

    public async Task<IActionResult> Index()
    {
        var cards = await _cardService.GetBlueEyesCardsAsync();
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

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
