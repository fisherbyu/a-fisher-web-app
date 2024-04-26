using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AFisherWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFisherWebApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class ApiController : Controller
    {
        // Attributes
        public AFisherDBContext DbContext { get; set; }
        public JsonSerializerOptions jsonSettings { get; set; }

        // Constructor
        public ApiController(AFisherDBContext context)
        {
            //Link DB
            DbContext = context;

            //Format JSON
            jsonSettings = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = true
            };
        }

        // Endpoints: --------------------------------------------------------------------------------------------------------------------

        // GET: api/
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                content = "Thanks for visiting my API!  Check fisherandrew.org for documentation"
            };

            return Json(data);
        }

        // GET: api/artist
        [HttpGet("artist")]
        public IActionResult GetArtists()
        {
            List<ArtistDto> artists = DbContext.Artists
                .Include(a => a.Image)
                .Include(a => a.Content)
                .Include(a => a.Tags)
                .Include(a => a.Link)
                .Select(a => new ArtistDto(a))
                .ToList();

            return Json(artists, jsonSettings);
        }

        // GET: api/artist/{id}

        // POST: api/artist
        [HttpPost("artist")]
        public IActionResult CreateArtist([FromBody] ArtistDto dto)
        {
            // Validate Input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add data to DB
            try
            {
                // Convert Dto to Artist
                Artist artist = dto.ToArtist();

                // Add values to DB
                DbContext.Add(artist);
                DbContext.AddRange(artist.Content);
                DbContext.AddRange(artist.Tags);
                DbContext.Add(artist.Link);
                DbContext.Add(artist.Image);

                // Save changes to the database
                DbContext.SaveChanges();

                return Ok("Success!");
            }
            catch (Exception ex)
            {
                // Log Error
                Console.Error.WriteLine($"Error creating artist: {ex.InnerException}");

                // Return a 500 Internal Server Error response
                return StatusCode(500, $"An error occurred while creating the artist. {ex.InnerException}");
            }
        }
    }
}

