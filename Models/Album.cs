using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace AFisherWebApp.Models
{
	public class Album
	{
        // Attributes
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
        // Constructors

        // For Creating a Dto from Json Inputs (Default)
        public AlbumDto()
        {
            Type = "Album";
        }

        // For Creating a Dto from an Artist
        public AlbumDto(Album album)
        {
            Id = album.Id;
            Rank = album.Rank;
            Name = album.Name;
            Type = "Album";
            Content = album.Content.Select(c => c.Text).ToList();
            Tags = album.Tags.Select(t => new TagDto { Title = t.Title, Content = t.Content }).ToList();
            Link = new LinkDto { AppleURI = album.Link.AppleURI, SpotifyURI = album.Link.SpotifyURI };
            Image = new ImageDto { Src = album.Image.Src, Alt = album.Image.Alt };
        }

        // Attributes
        public int? Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Content { get; set; }
        public List<TagDto> Tags { get; set; }
        public LinkDto Link { get; set; }
        public ImageDto Image { get; set; }

        // Methods
        public Album ToAlbum()
        {
            return new Album
            {
                Id = this.Id ?? 0,
                Rank = this.Rank,
                Name = this.Name,
                Content = this.Content.Select((text, index) => new Content { Text = text, Order =  index}).ToList(),
                Tags = this.Tags.Select(tagDto => new Tag { Title = tagDto.Title, Content = tagDto.Content }).ToList(),
                Link = new Link { AppleURI = this.Link.AppleURI, SpotifyURI = this.Link.SpotifyURI },
                Image = new Image { Src = this.Image.Src, Alt = this.Image.Alt }
            };
        }
    }
}

