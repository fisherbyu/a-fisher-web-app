using System;
using Microsoft.EntityFrameworkCore;

namespace AFisherWebApp.Models
{

    public class FisherAndrewDBContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Image> Images { get; set; }

        public FisherAndrewDBContext(DbContextOptions<FisherAndrewDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships
            modelBuilder.Entity<Content>()
                .HasOne(c => c.Artist)
                .WithMany(a => a.Content)
                .HasForeignKey(c => c.ArtistId)
                .IsRequired(false);

            modelBuilder.Entity<Content>()
                .HasOne(c => c.Album)
                .WithMany(a => a.Content)
                .HasForeignKey(c => c.AlbumId)
                .IsRequired(false);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Artist)
                .WithMany(a => a.Tags)
                .HasForeignKey(t => t.ArtistId)
                .IsRequired(false);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Album)
                .WithMany(a => a.Tags)
                .HasForeignKey(t => t.AlbumId)
                .IsRequired(false);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Link)
                .WithOne(l => l.Artist)
                .HasForeignKey<Link>(l => l.ArtistId)
                .IsRequired(false);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Link)
                .WithOne(l => l.Album)
                .HasForeignKey<Link>(l => l.AlbumId)
                .IsRequired(false);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Artist)
                .HasForeignKey<Image>(i => i.ArtistId)
                .IsRequired(false);

            modelBuilder.Entity<Album>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Album)
                .HasForeignKey<Image>(i => i.AlbumId)
                .IsRequired(false);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Artist)
                .WithOne(a => a.Image)
                .HasForeignKey<Image>(i => i.ArtistId)
                .IsRequired(false);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Album)
                .WithOne(a => a.Image)
                .HasForeignKey<Image>(i => i.AlbumId)
                .IsRequired(false);


        }
    }
}

