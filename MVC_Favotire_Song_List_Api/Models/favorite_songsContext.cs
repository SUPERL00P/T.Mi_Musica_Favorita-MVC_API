using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_Favotire_Song_List_Api.Models
{
    public partial class favorite_songsContext : DbContext
    {
        public favorite_songsContext()
        {
        }

        public favorite_songsContext(DbContextOptions<favorite_songsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Song> Songs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=LaContraseñaPropia;database=favorite_songs", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("songs");

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Group).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Year).HasColumnType("year");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
