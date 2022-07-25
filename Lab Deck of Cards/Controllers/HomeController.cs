using Lab_Deck_of_Cards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_Deck_of_Cards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CardsDAL cardsDAL = new CardsDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CardDisplay(int cards)
        {            
            CardsModel result = new CardsModel();
            if (cards >= result.remaining)
            {
                result = cardsDAL.DrawCards(cards);
            }
            else
            {
                cardsDAL.ShuffleCards();
                Console.WriteLine("You don't have enough cards left, re-shuffling now");
            }

            return View(result);
        }

        public IActionResult Draw()
        {
            return View();
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}