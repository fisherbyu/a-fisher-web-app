using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace AFisherWebApp.Models
{
    public class FisherAndrewDBContext : DbContext
    {
        public FisherAndrewDBContext(DbContextOptions<FisherAndrewDBContext> options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>()
                .HasOne(d => d.Artist)
                .WithOne(a => a.Description)
                .HasForeignKey<Description>(d => d.ArtistID);

            modelBuilder.Entity<Description>()
                .HasOne(d => d.Album)
                .WithOne(a => a.Description)
                .HasForeignKey<Description>(d => d.AlbumID);
        }
    }
}

