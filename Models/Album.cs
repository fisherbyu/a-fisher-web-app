using System;
namespace AFisherWebApp.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Title { get; set; }
        public List<Content> Contents { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Links { get; set; }
        public Image Image { get; set; }
    }
}

