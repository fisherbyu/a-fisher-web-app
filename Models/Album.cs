using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
    public class Album
    {
        [Key]
        [Required]
        public long AlbumId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string CoverURL { get; set; }
        [Required]
        public string AppleURI { get; set; }
        [Required]
        public string SpotifyURI { get; set; }

        // Navigation + Foreign Key
        public long DescriptionID { get; set; }
        public Description Description { get; set; }
    }
}

