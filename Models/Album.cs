using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
    public class Album
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Content> Content { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
    }

    
    public class AlbumDto
    {
        public int rank { get; set; }
        public string name { get; set; }
        public List<string> content { get; set; }
        public List<TagDto> tags { get; set; }
        public LinkDto link { get; set; }
        public ImageDto image { get; set; }

        // Constructor to Map Album to AlbumDto for Export
        public AlbumDto(Album album)
        {
            rank = album.Rank;
            name = album.Name;
            content = new List<string>();
            tags = new List<TagDto>();
            link = new LinkDto { appleURI = album.Link.AppleURI, spotifyURI = album.Link.SpotifyURI };
            image = new ImageDto { src = album.Image.Src, alt = album.Image.Alt };

            // Extract Lists for Content and Tags
            foreach (Content c in album.Content)
            {
                content.Add(c.Text);
            }

            foreach (Tag t in album.Tags)
            {
                tags.Add(new TagDto { title = t.Title, content = t.Content });
            }

        }
    }
}

