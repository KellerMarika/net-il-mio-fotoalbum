using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;
using System.Diagnostics;

namespace net_il_mio_fotoalbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PhotoAlbumContext _context;
        public HomeController(ILogger<HomeController> logger, PhotoAlbumContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Photo> photosList;
            photosList = _context.Photos
                 .Where(p => p.Visible == true)
                 .Include(p => p.Categories)
                 .ToList();
            return View(photosList.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SendMessage()
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