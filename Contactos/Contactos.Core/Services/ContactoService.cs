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
    public class ContactoService : IContactoService
    {
        private readonly IUnitOfWork work;

        public ContactoService(IUnitOfWork work)
        {
            this.work = work;
        }

        public IEnumerable<Contacto> GetAll(ContactoQueryFilters filters)
        {
            var all = this.work.ContactoRepo.GetAll();

            if (filters.Nombre != null)
            {
                all = all.Where(e => e.Nombre == filters.Nombre);
            }

            if (filters.Apellidos != null)
            {
                all = all.Where(e => e.Apellidos == filters.Apellidos);
            }


            return all;
        }

        public async Task<Contacto> GetById(int id)
        {
            return await this.work.ContactoRepo.GetById(id);
        }

        public async Task<bool> Add(Contacto usuario)
        {
            usuario.FechaRegistro = DateTime.Now;
            usuario.IdEstatus = 1;
            await this.work.ContactoRepo.Add(usuario);

            foreach (var item in usuario.Telefono)
            {
                item.FechaRegistro = DateTime.Now;
                item.IdEstatus = 1;
            }

            foreach (var item in usuario.Correo)
            {
                item.FechaRegistro = DateTime.Now;
                item.IdEstatus = 1;
            }

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await this.GetById(id);
            current.IdEstatus = 2;
            current.FeechaBaja = DateTime.Now;

            this.work.ContactoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }

        public async Task<bool> Update(Contacto usuario)
        {
            var current = await this.GetById(usuario.Id);
            current.Nombre = usuario.Nombre;
            current.Apellidos = usuario.Apellidos;
            current.FechaModificacion = DateTime.Now;

            this.work.ContactoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }
    }
}
