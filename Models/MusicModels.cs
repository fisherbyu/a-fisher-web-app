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

    public class Content
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Text { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }

    public class Tag
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }

    public class Link
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string AppleURI { get; set; }
        [Required]
        public string SpotifyURI { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }

    public class Image
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Src { get; set; }
        [Required]
        public string Alt { get; set; }
        public int? ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }



    // Data Transfer Objects:
    public class ArtistDto
    {
        public int Tier { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public List<string> Content { get; set; }
        public List<TagDto> Tags { get; set; }
        public LinkDto Link { get; set; }
        public ImageDto Image { get; set; }
    }

    public class AlbumDto
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public List<string> Content { get; set; }
        public List<TagDto> Tags { get; set; }
        public LinkDto Link { get; set; }
        public ImageDto Image { get; set; }
    }

    public class ContentDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
    }


    public class TagDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class LinkDto
    {
        public string AppleURI { get; set; }
        public string SpotifyURI { get; set; }
    }

    public class ImageDto
    {
        public string Src { get; set; }
        public string Alt { get; set; }
    }

    public class ArtistExportDto
    {
        public int id { get; set; }
        public int tier { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
        public List<string> content { get; set; }
        public string type = "Artist";
        public List<TagDto> tags { get; set; }
        public LinkDto links { get; set; }
        public ImageDto image { get; set; }

        // Constructor
        public ArtistExportDto(Artist artist)
        {
            id = artist.Id;
            tier = artist.Tier;
            rank = artist.Rank ?? 0;
            name = artist.Name;
            content = artist.Content.Select(c => c.Text).ToList();
            tags = artist.Tags.Select(t => new TagDto { Title = t.Title, Content = t.Content }).ToList();
            links = new LinkDto { AppleURI = artist.Link.AppleURI, SpotifyURI = artist.Link.SpotifyURI };
            image = new ImageDto { Src = artist.Image.Src, Alt = artist.Image.Alt };
        }
    }

    public class AlbumExportDto
    {
        public int id { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
        public List<string> content { get; set; }
        public string type = "Album";
        public List<TagDto> tags { get; set; }
        public LinkDto? links { get; set; }
        public ImageDto? image { get; set; }

        // Constructor
        public AlbumExportDto(Album album)
        {
            id = album.Id;
            rank = album.Rank;
            name = album.Name;
            content = album.Content.Select(c => c.Text).ToList();
            tags = album.Tags.Select(t => new TagDto { Title = t.Title, Content = t.Content }).ToList();
            links = new LinkDto { AppleURI = album.Link.AppleURI, SpotifyURI = album.Link.SpotifyURI };
            image = new ImageDto { Src = album.Image.Src, Alt = album.Image.Alt };
        }
    }
}

