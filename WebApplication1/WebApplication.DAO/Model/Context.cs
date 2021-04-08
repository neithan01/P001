using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication.DAO.Model
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }



        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=GeoLocalization;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.County).HasColumnName("county");

                entity.Property(e => e.PostalCode).HasColumnName("postalCode");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
