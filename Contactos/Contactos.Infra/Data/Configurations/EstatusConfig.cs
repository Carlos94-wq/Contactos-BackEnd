using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    public class EstatusConfig : IEntityTypeConfiguration<Estatus>
    {
        public void Configure(EntityTypeBuilder<Estatus> entity)
        {
            entity.HasKey(e => e.IdEstatus)
                   .HasName("PK_Estatus_IdEstatus");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
