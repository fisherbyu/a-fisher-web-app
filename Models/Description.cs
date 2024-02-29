using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
    public class Description
    {
        [Key]
        [Required]
        public long DescriptionID { get; set; }
        [Required]
        public string Content { get; set; }

        // Nullable foreign key properties
        public long? ArtistID { get; set; }
        public long? AlbumID { get; set; }

        // Navigation properties
        public Artist Artist { get; set; }
        public Album Album { get; set; }
    }
}

