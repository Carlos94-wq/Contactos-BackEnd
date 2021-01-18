using Contactos.Core.CustonEntities;
using Contactos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<Usuario> Login(UserCredentials credentials);
    }
}
