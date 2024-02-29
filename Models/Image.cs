using System;
namespace AFisherWebApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int EntityId { get; set; } // Foreign key for either an album or an artist
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}

