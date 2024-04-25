using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
	public class Image
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Src { get; set; }
        [Required]
        public string Alt { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}

