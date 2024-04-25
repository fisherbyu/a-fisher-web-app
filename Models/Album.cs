using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace AFisherWebApp.Models
{
	public class Album
	{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Content> Content { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
    }
}

