using System;
namespace AFisherWebApp.Models
{
    public class Content
    {
        public int Id { get; set; }
        public int EntityId { get; set; } // Foreign key for either an album or an artist
        public string Text { get; set; }
    }
}

