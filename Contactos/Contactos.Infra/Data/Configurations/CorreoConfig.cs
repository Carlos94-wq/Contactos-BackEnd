using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    public class CorreoConfig : IEntityTypeConfiguration<Correo>
    {
        public void Configure(EntityTypeBuilder<Correo> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_Correo_IdTelefono");

            entity.Property(e => e.Id)
                .HasColumnName("IdCorrep");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FechaModificacion).HasColumnType("date");

            entity.Property(e => e.FechaRegistro).HasColumnType("date");

            entity.Property(e => e.FeechaBaja).HasColumnType("date");

            entity.HasOne(d => d.IdContactoNavigation)
                .WithMany(p => p.Correo)
                .HasForeignKey(d => d.IdContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Correo_IdContacto");

            entity.HasOne(d => d.IdEstatusNavigation)
                .WithMany(p => p.Correo)
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Correo_IdEstatus");

            entity.HasOne(d => d.IdTipoCorreoNavigation)
                .WithMany(p => p.Correo)
                .HasForeignKey(d => d.IdTipoCorreo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Correo_IdTipoTelefono");
        }
    }
}
