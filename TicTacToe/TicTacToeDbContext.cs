using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TicTacToe.Entities;

#nullable disable

namespace TicTacToe
{
    public partial class TicTacToeDbContext : DbContext
    {
        public TicTacToeDbContext()
        {
        }

        public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<PlayField> PlayFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.utf8");

            modelBuilder.Entity<PlayField>(entity =>
            {
                entity.HasKey(e => e.PFuk)
                    .HasName("pf_pkey");
                entity.ToTable("pf");

                entity.Property(e => e.PFuk)
                    .ValueGeneratedNever()
                    .HasColumnName("pfuk");
                entity.Property(e => e.PFturn)
                    .HasColumnName("pfturn");

                entity.Property(e => e.PF)
                    .HasColumnName("pf");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
