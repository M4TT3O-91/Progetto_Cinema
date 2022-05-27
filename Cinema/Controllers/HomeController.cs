using Cinema.DataManager.Interface;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFilmDataManager _filmDataManager;
        private readonly IMovieRoomsDataManager _movieRoomsDataManager;

        public HomeController(ILogger<HomeController> logger, IFilmDataManager filmDataManager, IMovieRoomsDataManager movieRoomsDataManager)
        {
            _logger = logger;
            _filmDataManager = filmDataManager;
            _movieRoomsDataManager = movieRoomsDataManager;
        }

        public IActionResult Index()
        {
            var film = _filmDataManager.get
            
            
            return View();
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
}