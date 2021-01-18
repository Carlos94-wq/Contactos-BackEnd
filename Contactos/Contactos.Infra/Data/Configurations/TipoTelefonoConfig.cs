using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    public class TipoTelefonoConfig : IEntityTypeConfiguration<TipoTelefono>
    {
        public void Configure(EntityTypeBuilder<TipoTelefono> entity)
        {
            entity.HasKey(e => e.IdTipoTelefono)
                   .HasName("PK_Tipo_Telefono_IdTelefono");

            entity.ToTable("Tipo_Telefono");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
