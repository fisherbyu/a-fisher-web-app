using System;
namespace AFisherWebApp.Models
{
    public class Link
    {
        public int Id { get; set; }
        public int EntityId { get; set; } // Foreign key for either an album or an artist
        public string AppleURI { get; set; }
        public string SpotifyURI { get; set; }
    }
}

