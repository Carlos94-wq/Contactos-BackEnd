using System;
using Contactos.Core.Entities;
using Contactos.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Contactos.Infra.Data
{
    public partial class DBCONTACTOSContext : DbContext
    {
        public DBCONTACTOSContext()
        {
        }

        public DBCONTACTOSContext(DbContextOptions<DBCONTACTOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Correo> Correo { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Telefono> Telefono { get; set; }
        public virtual DbSet<TipoCorreo> TipoCorreo { get; set; }
        public virtual DbSet<TipoTelefono> TipoTelefono { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new ContactoConfig() );
            modelBuilder.ApplyConfiguration( new CorreoConfig() );
            modelBuilder.ApplyConfiguration( new EstatusConfig() );
            modelBuilder.ApplyConfiguration( new RolConfig() );
            modelBuilder.ApplyConfiguration( new TelefonoConfig() );
            modelBuilder.ApplyConfiguration( new TipoCorreoConfig() );
            modelBuilder.ApplyConfiguration( new TipoTelefonoConfig() );
            modelBuilder.ApplyConfiguration( new UsuarioConfig() );
        }
    }
}
