using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    class TelefonoConfig : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_Telefono_IdTelefono");

            entity.Property(e => e.Id)
                .HasColumnName("IdTelefono");

            entity.Property(e => e.FechaModificacion).HasColumnType("date");

            entity.Property(e => e.FechaRegistro).HasColumnType("date");

            entity.Property(e => e.FeechaBaja).HasColumnType("date");

            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdContactoNavigation)
                .WithMany(p => p.Telefono)
                .HasForeignKey(d => d.IdContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Telefono_IdContacto");

            entity.HasOne(d => d.IdEstatusNavigation)
                .WithMany(p => p.Telefono)
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Telefono_IdEstatus");

            entity.HasOne(d => d.IdTipoTelefonoNavigation)
                .WithMany(p => p.Telefono)
                .HasForeignKey(d => d.IdTipoTelefono)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PK_Telefono_IdTipoTelefono");
        }
    }
}
