using System;
using System.ComponentModel.DataAnnotations;

namespace AFisherWebApp.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Tier { get; set; }
        public int? Rank { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Content> Content { get; set; }
        public List<Tag> Tags { get; set; }
        public Link Link { get; set; }
        public Image Image { get; set; }
    }

    // Data Transfer Object:
    public class ArtistDto
    {
        public int tier { get; set; }
        public int? rank { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<string> content { get; set; }
        public List<TagDto> tags { get; set; }
        public LinkDto link { get; set; }
        public ImageDto image { get; set; }

        // Constructor to Map Artist to ArtistDto for Export
        public ArtistDto(Artist artist)
        {
            tier = artist.Tier;
            rank = artist.Rank;
            name = artist.Name;
            type = "Artist";
            content = new List<string>();
            tags = new List<TagDto>();
            link = new LinkDto { appleURI = artist.Link.AppleURI, spotifyURI = artist.Link.SpotifyURI };
            image = new ImageDto { src = artist.Image.Src, alt = artist.Image.Alt };

            // Extract Lists for Content and Tags
            foreach(Content c in artist.Content)
            {
                content.Add(c.Text);
            }

            foreach (Tag t in artist.Tags)
            {
                tags.Add(new TagDto { title = t.Title, content = t.Content });
            }
        }
    }


}

