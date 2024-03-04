using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace AFisherWebApp.Models
{
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
            tags = artist.Tags.Select(t => new TagDto { title = t.Title, content = t.Content }).ToList();
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
            tags = album.Tags.Select(t => new TagDto { title = t.Title, content = t.Content }).ToList();
            links = new LinkDto { AppleURI = album.Link.AppleURI, SpotifyURI = album.Link.SpotifyURI };
            image = new ImageDto { Src = album.Image.Src, Alt = album.Image.Alt };
        }
    }
}

