using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Repositories
{
    public interface IUnitOfWork: IDisposable
    {   
        IBaseRepository<Usuario> UsuarioRepo { get; }
        IBaseRepository<Contacto> ContactoRepo { get; }
        IBaseRepository<Telefono> TelefonoRepo { get; }
        IBaseRepository<Correo> CorreoRepo { get; }
        ICatalogoRepository CatalogoRepo { get; }
        IAuthRepository AuthRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
