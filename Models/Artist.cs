using System;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using Newtonsoft.Json;


namespace AFisherWebApp.Models
{
	public class Artist
	{
        // Attributes
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

    public class ArtistDto
    {
        // Constructors

        // For Creating a Dto from Json Inputs (Default)
        public ArtistDto()
        {
            Type = "Album";
        }

        // For Creating a Dto from an Artist
        public ArtistDto(Artist artist)
        {
            Id = artist.Id;
            Tier = artist.Tier;
            Rank = artist.Rank;
            Name = artist.Name;
            Type = "Artist";
            Content = artist.Content.Select(c => c.Text).ToList();
            Tags = artist.Tags.Select(tag => new TagDto { Title = tag.Title, Content = tag.Content }).ToList();
            Link = new LinkDto { AppleURI = artist.Link.AppleURI, SpotifyURI = artist.Link.SpotifyURI };
            Image = new ImageDto { Src = artist.Image.Src, Alt = artist.Image.Alt };
        }

        // Attributes
        public int? Id { get; set; }
        public int Tier { get; set; }
        public int? Rank { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Content { get; set; }
        public List<TagDto> Tags { get; set; }
        public LinkDto Link { get; set; }
        public ImageDto Image { get; set; }

        // Methods
        public Artist ToArtist()
        {
            return new Artist
            {
                Id = this.Id ?? 0,
                Tier = this.Tier,
                Rank = this.Rank,
                Name = this.Name,
                Content = this.Content.Select((text, index) => new Content { Text = text, Order = index }).ToList(),
                Tags = this.Tags.Select(tagDto => new Tag { Title = tagDto.Title, Content = tagDto.Content }).ToList(),
                Link = new Link { AppleURI = this.Link.AppleURI, SpotifyURI = this.Link.SpotifyURI },
                Image = new Image { Src = this.Image.Src, Alt = this.Image.Alt }
            };
        }
    }
}

