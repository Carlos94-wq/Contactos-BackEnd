using Contactos.Core.Interfaces.Repositories;
using Contactos.Core.Interfaces.Services;
using Contactos.Core.Services;
using Contactos.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contactos.Infra.Extentsions
{
    public static class ServicessCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IContactoService, ContactoService>();
            services.AddTransient<ITelefonoService, TelefonoService>();
            services.AddTransient<ICorreoService, CorreoService>();

            return services;
        }
    }
}
