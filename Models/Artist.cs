using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;

namespace AFisherWebApp.Models
{
	public class Artist
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Tier { get; set; }
        public int? Rank { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Content> Content { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
    }
}

