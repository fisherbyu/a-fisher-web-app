using System;
namespace AFisherWebApp.Models
{
	public class DataExport
	{
        // Attributes
        public int id { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
        public List<string> content { get; set; }
        public string type { get; set; }
        public List<TagDto> tags { get; set; }
        public LinkExport links { get; set; }
        public ImageExport image { get; set; }


        // Child Data Classes
        
        public class LinkExport
        {
            public string appleURI { get; set; }
            public string spotifyURI { get; set; }
        }
        public class ImageExport
        {
            public string src { get; set; }
            public string alt { get; set; }
        }
    }

    public class ArtistExport : DataExport
    {
        // Additional Attribute
        public int tier { get; set; }

        // Constructor
        //public ArtistExport(Artist artist)
        //{
        //    id = artist.Id;
        //    tier = artist.Tier;
        //    rank = artist.Rank;

        //}
    }
}

