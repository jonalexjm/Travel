﻿
using Microsoft.EntityFrameworkCore;
using Travel.Core.Entities;
using Travel.Infrastructure.Data.Configurations;


#nullable disable

namespace Travel.Infrastructure.Data
{
    public partial class TravelDbContext : DbContext
    {

        public TravelDbContext()
        {
        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }
        public virtual DbSet<Editorial> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TravelDb;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new AutorConfigurations());
            modelBuilder.ApplyConfiguration(new AutoresHasLibroConfigurations());
            modelBuilder.ApplyConfiguration(new EditorialConfigurations());
            modelBuilder.ApplyConfiguration(new LibroConfigurations());

        }
     
    }
}
