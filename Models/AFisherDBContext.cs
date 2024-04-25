using System;
using Microsoft.EntityFrameworkCore;

namespace AFisherWebApp.Models
{
	public class AFisherDBContext: DbContext
	{
        // Define Tables
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Image> Images { get; set; }

        // Constructor
        public AFisherDBContext(DbContextOptions<AFisherDBContext> options) : base(options)
        {
        }

        // Define Table Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Link Artist Entity to its attributes

            // Define one to many: Artist 0..1 -------- 1..* Content
            // Artist has many Content
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Content)            // Artist has many Content
                .WithOne(c => c.Artist)             // Content Has one Artist
                .HasForeignKey(c => c.ArtistId);    // Content connects on ArtistId

            // Content has one Artist
            modelBuilder.Entity<Content>()
                .HasOne(c => c.Artist)              // Content has one Artist
                .WithMany(a => a.Content)           // Artist has many Content
                .HasForeignKey(c => c.ArtistId)     // Content connects on ArtistId
                .IsRequired(false);                 // Content doesn't always link to Artist

            // Define one to many: Artist 0..1 -------- 1..* Tag
            // Artist has many Tag
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Tags)               // Artist has many Tag
                .WithOne(t => t.Artist)             // Tag Has one Artist
                .HasForeignKey(t => t.ArtistId);    // Tag connects on ArtistId

            // Tag has one Artist
            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Artist)              // Tag has one Artist
                .WithMany(a => a.Tags)              // Artist has many Tag
                .HasForeignKey(t => t.ArtistId)     // Tag connects on ArtistId
                .IsRequired(false);                 // Tag doesn't always link to Artist

            // Define one to one: Artist 0..1 -------- 1..1 Link
            // Artist has one Link
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Link)                    // Artist has one Tag
                .WithOne(l => l.Artist)                 // Tag has one Artist
                .HasForeignKey<Link>(l => l.ArtistId);  // Link connects





                    //.HasMany(a => a.Tags)
                    //.WithOne(t => t.Artist)
                    //.HasForeignKey(t => t.ArtistId);

                // Content has one Artist
                modelBuilder.Entity<Tag>()
                    .HasOne(t => t.Artist)
                    .WithMany(a => a.Tags)
                    .HasForeignKey(t => t.ArtistId)
                    .IsRequired(false);

        }
    }
}

