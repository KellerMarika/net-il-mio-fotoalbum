using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using net_il_mio_fotoalbum.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace net_il_mio_fotoalbum.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly PhotoAlbumContext _context;
        public PhotoController(PhotoAlbumContext context)
        {
            _context = context;
        }

        // GET: api/Photo
        [HttpGet]
        public IActionResult Index(string? queryText)//overload
        {
            List<Photo> photosList;
            photosList = _context.Photos.Where(p => p.Visible == true).ToList();
            if (queryText != null)
            {
                photosList=photosList.Where(p=>p.Title.ToLower().Contains(queryText.ToLower()))
                 .ToList();
            }
            return Ok(photosList); 
        }

        //CREA messaggio
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message data)      // gestisce richieste POST /api/Photo
        {
            Message newMex = new Message(data.Text, data.Email);
            _context.Messages.Add(newMex);
            _context.SaveChanges();
            return Ok();
        }
    }
}
