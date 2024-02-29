using System;
namespace AFisherWebApp.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int EntityId { get; set; } // Foreign key for either an album or an artist
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

