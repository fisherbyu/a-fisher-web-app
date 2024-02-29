using System;
namespace AFisherWebApp.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public int Tier { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public List<Content> Contents { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Links { get; set; }
        public Image Image { get; set; }
    }
}

