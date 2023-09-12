using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TwitterClone.Models;
using TwitterClone.Repositories;

namespace TwitterClone.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITweetRepository tweetRepository;

        public HomeController(ILogger<HomeController> logger, ITweetRepository _tweetRepository)
        {
            _logger = logger;
            tweetRepository = _tweetRepository;
        }

        public IActionResult Index()
        {
            var tweets = tweetRepository.GetAll();
            return View(tweets);
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