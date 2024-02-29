using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public long ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhotoURL { get; set; }
        [Required]
        public string AppleURI { get; set; }
        [Required]
        public string SpotifyURI { get; set; }

        // Navigation + Foreign Key
        public long DescriptionID { get; set; }
        public Description Description { get; set; }
    }
}

