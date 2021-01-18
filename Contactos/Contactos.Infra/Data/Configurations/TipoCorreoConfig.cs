using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    public class TipoCorreoConfig : IEntityTypeConfiguration<TipoCorreo>
    {
        public void Configure(EntityTypeBuilder<TipoCorreo> entity)
        {
            entity.HasKey(e => e.IdTipoCorreo)
                   .HasName("PK_Tipo_Correo_IdCorreo");

            entity.ToTable("Tipo_Correo");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
