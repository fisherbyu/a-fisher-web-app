using System;
using System.ComponentModel.DataAnnotations;

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

    // Data Transfer Object:
    public class ArtistDto
    {
        public int tier { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
        public List<string> content { get; set; }
        public List<TagDto> tags { get; set; }
        public LinkDto link { get; set; }
        public ImageDto image { get; set; }
    }
}

