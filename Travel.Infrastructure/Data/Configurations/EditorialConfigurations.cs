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
    public class EditorialConfigurations : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("editoriales");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.Property(e => e.Sede)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sede");
        }
    }
}
