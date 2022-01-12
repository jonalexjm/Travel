using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Infrastructure.Data.Configurations
{
    public class AutoresHasLibroConfigurations : IEntityTypeConfiguration<AutoresHasLibro>
    {
        public void Configure(EntityTypeBuilder<AutoresHasLibro> builder)
        {
            //builder.HasNoKey();

            builder.ToTable("autores_has_libros");

            builder.Property(e => e.AutoresId).HasColumnName("autores_id");

            builder.Property(e => e.LibrosIsbn).HasColumnName("libros_ISBN");

            builder.HasOne(d => d.Autores)
                .WithMany()
                .HasForeignKey(d => d.AutoresId)
                .HasConstraintName("fk_autores");

            builder.HasOne(d => d.LibrosIsbnNavigation)
                .WithMany()
                .HasForeignKey(d => d.LibrosIsbn)
                .HasConstraintName("fk_libros");
        }
    }
}
