using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
	public class Tag
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}

