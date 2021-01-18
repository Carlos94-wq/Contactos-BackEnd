using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        IBaseRepository<Usuario> _UsuarioRepo;
        IBaseRepository<Contacto> _ContactoRepo;
        IBaseRepository<Telefono> _TelefonoRepo;
        IBaseRepository<Correo> _CorreoRepo;
        ICatalogoRepository _Catalogo;
        IAuthRepository _Auth;

        private readonly DBCONTACTOSContext _Context;

        public UnitOfWork( DBCONTACTOSContext context)
        {
            this._Context = context;
        }

        public IBaseRepository<Usuario> UsuarioRepo => _UsuarioRepo ?? new BaseRepository<Usuario>(_Context);
        public IBaseRepository<Contacto> ContactoRepo => _ContactoRepo ?? new BaseRepository<Contacto>(_Context);
        public IBaseRepository<Telefono> TelefonoRepo => _TelefonoRepo ?? new BaseRepository<Telefono>(_Context);
        public IBaseRepository<Correo> CorreoRepo => _CorreoRepo ?? new BaseRepository<Correo>(_Context);
        public ICatalogoRepository CatalogoRepo => _Catalogo ?? new CatalogoRepository(_Context);
        public IAuthRepository AuthRepo => _Auth ?? new AuthRepository(_Context);

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this._Context.SaveChangesAsync();
        }
    }
}
