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
    public class LibroConfigurations : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.HasKey(e => e.Isbn)
                    .HasName("PK__libros__447D36EB4C3CED32");

            builder.ToTable("libros");

            builder.Property(e => e.Isbn).HasColumnName("ISBN");

            builder.Property(e => e.Editoriales).HasColumnName("editoriales");

            builder.Property(e => e.NPaginas)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");

            builder.Property(e => e.Sinopsis)
                .HasColumnType("text")
                .HasColumnName("sinopsis");

            builder.Property(e => e.Titulo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("titulo");

            builder.HasOne(d => d.EditorialesNavigation)
                .WithMany(p => p.Libros)
                .HasForeignKey(d => d.Editoriales)
                .HasConstraintName("fk_editoriales");
        }
    }
}
