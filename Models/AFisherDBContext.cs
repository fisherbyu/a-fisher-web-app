using System;
using Microsoft.EntityFrameworkCore;

namespace AFisherWebApp.Models
{
    public class AFisherDBContext : DbContext
    {
        // Configure Constructor
        public AFisherDBContext(DbContextOptions<AFisherDBContext> options)
            : base(options)
        { }

        // Define Tables
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Image> Images { get; set; }
        
        // Define Entiy Relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Artist Relationships
            // Artist 0..1 ---- 1..* Content
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Content)
                .WithOne(c => c.Artist)
                .HasForeignKey(c => c.ArtistId);

            // Artist 0..1 ---- 1..* Tag
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Tags)
                .WithOne(t => t.Artist)
                .HasForeignKey(t => t.ArtistId);

            // Artist 0..1 ---- 1..1 Link
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Link)
                .WithOne(l => l.Artist)
                .HasForeignKey<Link>(l => l.ArtistId);

            // Artist 0..1 ---- 1..1 Image
            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Artist)
                .HasForeignKey<Image>(i => i.ArtistId);

            // Configure Album Relationships
            // Album 0..1 ---- 1..* Content
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Content)
                .WithOne(c => c.Album)
                .HasForeignKey(c => c.AlbumId);

            // Album 0..1 ---- 1..* Tag
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tags)
                .WithOne(t => t.Album)
                .HasForeignKey(t => t.AlbumId);

            // Album 0..1 ---- 1..1 Link
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Link)
                .WithOne(l => l.Album)
                .HasForeignKey<Link>(l => l.AlbumId);

            // Artist 0..1 ---- 1..1 Image
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Album)
                .HasForeignKey<Image>(i => i.AlbumId);
        }
    }
}

