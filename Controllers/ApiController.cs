using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AFisherWebApp.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Learn_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : Controller
    {
        public FisherAndrewDBContext DbContext { get; set; }
        public JsonSerializerOptions jsonSettings { get; set; }
        public APIController(FisherAndrewDBContext context)
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

        // GET: api/
        [HttpGet]
        public IActionResult Get()
        {
            var data = new
            {
                content = "Thanks for visiting my API!  Check fisherandrew.org for documentation"
            };

            return Json(data, jsonSettings);

        }

        // GET: api/artist
        [HttpGet("artist")]
        public IActionResult GetArtists()
        {
            //List<Artist> artists = DbContext.Artists
            //    .Include(a => a.Image)
            //    .Include(a => a.Content)
            //    .Include(a => a.Tags)
            //    .Include(a => a.Link)
            //    .ToList();

            //List<ArtistExportDto> exportArtists = artists
            //    .Select(a => new ArtistExportDto(a))
            //    .ToList();

            var artists = DbContext.Artists
                .Include(a => a.Image)
                .Include(a => a.Content)
                .Include(a => a.Tags)
                .Include(a => a.Link)
                .Select(a => new
                {
                    a.Id,
                    a.Tier,
                    a.Rank,
                    a.Name,
                    a.Content,
                    Type = "Artist",
                    a.Tags,
                    a.Link,
                    a.Image
                })
                .ToList();
                

            return Json(artists, jsonSettings);
        }

        // GET: api/artist/{id}
        [HttpGet("artist/{id}")]
        public IActionResult GetArtist(int id)
        {
            Artist artist = DbContext.Artists
            .Include(a => a.Image)
            .Include(a => a.Content)
            .Include(a => a.Tags)
            .Include(a => a.Link)
            .FirstOrDefault(a => a.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            var exportArtist = new ArtistExportDto(artist);

            return Json(exportArtist, jsonSettings);


        }

        // GET: api/album
        [HttpGet("album")]
        public IActionResult GetAlbums()
        {
            var albums = DbContext.Albums
                    .Include(a => a.Image)
                    .Include(a => a.Content)
                    .Include(a => a.Tags)
                    .Include(a => a.Link)
                    .Select(a => new
                    {
                        a.Id,
                        a.Rank,
                        a.Name,
                        a.Content,
                        Type = "Album",
                        a.Tags,
                        a.Link,
                        a.Image
                    })
                    .ToList();


            return Json(albums, jsonSettings);
        }

        // GET: api/album/{id}
        [HttpGet("album/{id}")]
        public IActionResult GetAlbum(int id)
        {
            var album = DbContext.Albums
                    .Include(a => a.Image)
                    .Include(a => a.Content)
                    .Include(a => a.Tags)
                    .Include(a => a.Link)
                    .Where(a => a.Id == id)
                    .Select(a => new
                    {
                        a.Id,
                        a.Rank,
                        a.Name,
                        a.Content,
                        Type = "Album",
                        a.Tags,
                        a.Link,
                        a.Image
                    })
                    .FirstOrDefault();

            return Json(album, jsonSettings);
        }

        // POST: api/artist
        [HttpPost("artist")]
        public IActionResult CreateArtist([FromBody] ArtistDto dto)
        {
            // Validate Input
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add Data to the Database
            try
            {
                // Map the ArtistDto to an Artist entity
                Artist artist = new Artist
                {
                    Tier = dto.Tier,
                    Rank = dto.Rank,
                    Name = dto.Name,
                    Content = new List<Content>(),
                    Tags = new List<Tag>(),
                    Link = new Link
                    {
                        AppleURI = dto.Link.AppleURI,
                        SpotifyURI = dto.Link.SpotifyURI
                    }
                };

                // Add the artist and related entities to the context
                DbContext.Artists.Add(artist);

                // Save changes to the database
                DbContext.SaveChanges();

                // Extract Content
                for (int i = 0; i < dto.Content.Count; i++)
                {
                    artist.Content.Add(new Content { Order = (i + 1), Text = dto.Content[i], ArtistId = artist.Id });
                }

                //Extract Tags
                foreach (TagDto tagDto in dto.Tags)
                {
                    artist.Tags.Add(new Tag { Title = tagDto.Title, Content = tagDto.Content, ArtistId = artist.Id });
                }

                // Save changes again to update Content and Tags with the correct ArtistId
                DbContext.SaveChanges();

                //var data = new
                //{
                //    id = artist.Id,

                //}
                return Ok();
            }
            catch (Exception ex)
            {
                // Log Error
                Console.Error.WriteLine($"Error creating artist: {ex.Message}");
                // Return a 500 Internal Server Error response
                return StatusCode(500, "An error occurred while creating the artist.");
            }



            
        }

    }
}








