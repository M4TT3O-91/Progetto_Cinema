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
            
            var rooms = _movieRoomsDataManager.GetMovieRoomByCinemaID(1);
            foreach (var item in rooms)
            {
                var film = _filmDataManager.GetFilmByID(item.FilmID);
                item.FilmTitle = film.Title;
            }
            return View(rooms);
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