using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
	public class Content
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Text { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}

