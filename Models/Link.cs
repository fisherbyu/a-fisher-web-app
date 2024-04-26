using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
	public class Link
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string AppleURI { get; set; }
        [Required]
        public string SpotifyURI { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }

    public class LinkDto
    {
        public string AppleURI { get; set; }
        public string SpotifyURI { get; set; }
    }
}

