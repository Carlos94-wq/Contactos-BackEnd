using Contactos.Core.CustonEntities;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Contactos.Infra.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DBCONTACTOSContext context;

        public AuthRepository( DBCONTACTOSContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> Login(UserCredentials credentials)
        {
            return await this.context.Usuario.FirstOrDefaultAsync( 
                e => e.Correo == credentials.Correo && e.Contrasenia == credentials.Contrasenia 
            );
        }
    }
}
