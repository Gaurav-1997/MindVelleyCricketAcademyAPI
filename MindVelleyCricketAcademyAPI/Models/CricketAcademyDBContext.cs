using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MindVelleyCricketAcademyAPI.Models
{
    public partial class CricketAcademyDBContext : DbContext
    {
        public CricketAcademyDBContext()
        {
        }

        public CricketAcademyDBContext(DbContextOptions<CricketAcademyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PlayerTable> PlayerTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=CricketDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTable>(entity =>
            {
                entity.ToTable("PlayerTable");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatchPlayed).HasColumnName("Match_Played");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OutOnDuck).HasColumnName("Out_on_Duck");

                entity.Property(e => e.RunScored).HasColumnName("Run_Scored");

                entity.Property(e => e.TypeOfPlayer)
                    .HasColumnName("Type_Of_Player")
                    .HasMaxLength(20);

                entity.Property(e => e.Wickets).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
