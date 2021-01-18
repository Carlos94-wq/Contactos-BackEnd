using System;
using System.Collections.Generic;
using System.Text;
using Contactos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contactos.Infra.Data.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_Usuario_IdUsuario");

            entity.Property(e => e.Id)
                .HasColumnName("IdUsuario");

            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Contrasenia)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FechaModificacion).HasColumnType("date");

            entity.Property(e => e.FechaRegistro).HasColumnType("date");

            entity.Property(e => e.FeechaBaja).HasColumnType("date");

            entity.Property(e => e.IdRol).HasColumnName("IdRol");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstatusNavigation)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdEstatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_IdEstatus");

            entity.HasOne(d => d.IrolNavigation)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_IdRol");
        }
    }
}
