using Contactos.Core.CustonEntities;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Core.Interfaces.Services;
using Contactos.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork work;

        public UsuarioService( IUnitOfWork work)
        {
            this.work = work;
        }

        public IEnumerable<Usuario> GetAll(UsuarioQueryFilters filters)
        {
            var all = this.work.UsuarioRepo.GetAll();

            if ( filters.Nombre != null )
            {
               all = all.Where( e=> e.Nombre == filters.Nombre );
            }

            if (filters.Correo != null)
            {
                all = all.Where(e => e.Correo == filters.Correo);
            }

            if (filters.Apellidos != null)
            {
                all = all.Where(e => e.Apellidos == filters.Apellidos);
            }

            if (filters.Rol != null)
            {
                all = all.Where(e => e.IdRol == filters.Rol);
            }

            if (filters.Estatus != null)
            {
                all = all.Where(e => e.IdEstatus == filters.Estatus);
            }

            return all;
        }

        public async Task<Usuario> GetById(int id)
        {
            return await this.work.UsuarioRepo.GetById(id);
        }

        public async Task<bool> Add(Usuario usuario)
        {
            UsuarioQueryFilters filters = new UsuarioQueryFilters();
            filters.Correo = usuario.Correo;

            var exists = this.GetAll(filters);

            if (exists.Count() == 1)
            {
                return false;
            }
            else
            {
                usuario.FechaRegistro = DateTime.Now;
                usuario.IdEstatus = 1;
                await this.work.UsuarioRepo.Add(usuario);

                var row = await this.work.SaveChangesAsync();

                return row > 0;
            }          
        }

        public async Task<bool> Delete(int id)
        {
            var current = await this.GetById(id);
            current.IdEstatus = 2;
            current.FeechaBaja = DateTime.Now;

            this.work.UsuarioRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }

        public async Task<bool> Update(Usuario usuario)
        {

            UsuarioQueryFilters filters = new UsuarioQueryFilters();
            filters.Correo = usuario.Correo;

            var exists = this.GetAll(filters);

            if (exists.Count() == 1)
            {
                return false;
            }
            else
            {
                var current = await this.GetById(usuario.Id);
                current.Nombre = usuario.Nombre;
                current.Apellidos = usuario.Apellidos;
                current.Contrasenia = usuario.Contrasenia;
                current.FechaModificacion = DateTime.Now;

                this.work.UsuarioRepo.Delete(current);

                var row = await this.work.SaveChangesAsync();

                return row > 0;
            }           
        }
    }
}
