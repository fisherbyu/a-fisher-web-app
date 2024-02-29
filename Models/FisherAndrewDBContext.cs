using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using AFisherWebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace AFisherWebApp.Models
{

    public class FisherAndrewDBContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Content> Contents { get; set; }

        public FisherAndrewDBContext(DbContextOptions<FisherAndrewDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Contents)
                .WithOne()
                .HasForeignKey(c => c.EntityId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Tags)
                .WithOne()
                .HasForeignKey(t => t.EntityId);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Links)
                .WithOne()
                .HasForeignKey<Link>(l => l.EntityId);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Image)
                .WithOne()
                .HasForeignKey<Image>(i => i.EntityId);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Contents)
                .WithOne()
                .HasForeignKey(c => c.EntityId);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tags)
                .WithOne()
                .HasForeignKey(t => t.EntityId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Links)
                .WithOne()
                .HasForeignKey<Link>(l => l.EntityId);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Image)
                .WithOne()
                .HasForeignKey<Image>(i => i.EntityId);


            // Seed data
            modelBuilder.Entity<Content>().HasData(
                new Content
                {
                    Id = 1,
                    EntityId = 7, // Album Id
                    Text = "\"It was just time for us to make an album about hope and love and togetherness\"-Chris Martin. A Head Full of Dreams is my favorite Coldplay Album, and its central theme is the graduation and application of the hopeful yearning found in past albums. A Head Full of Dreams stand in contrast as the day to the night that was Ghost Stories. Ghost Stories was raw and depressing and overwhelmingly dark, AHFOD enlightens us once again to the joy found in everyday life. The album cover alone, with its rainbow circle of life, bursting with color is directly contrasted to the darkness that was Ghost Stories. \"A Head Full of Dreams,\" \"Birds\" and \"Fun\" are upbeat and hopeful alternative hits that draw us into the irrepressible happiness of the album. At the same time, songs like \"Hymn for the Weekend\" and \"Adventure a Lifetime\" fuse conventional alternative with bright and colorful pop-rock. Musically, \"Birds\" and \"Up&Up\" draw you in with their driven beats and uplifting chords, while \"Amazing Day\" surrounds you with feelings of peaceful love."
                },
                new Content
                {

                }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    EntityId = 7, // Album Id
                    Title = "Favorite Tracks:",
                    Content = "Coloratura, Let Somebody Know"
                }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link
                {
                    Id = 1,
                    EntityId = 7, // Album Id
                    AppleURI = "a-head-full-of-dreams/1053933969",
                    SpotifyURI = "3cfAM8b8KqJRoIzt3zLKqw"
                }
            );

            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = 1,
                    EntityId = 7, // Album Id
                    Src = "/music/coldplay-albums/a-head-full-of-dreams.jpg",
                    Alt = "Album Cover, A Head Full of Dreams - Coldplay"
                }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 7,
                    Rank = 1,
                    Title = "A Head Full of Dreams"
                }
            );





        }

        
    }

}

