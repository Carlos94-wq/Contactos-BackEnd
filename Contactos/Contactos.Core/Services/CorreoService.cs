using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Core.Interfaces.Services;

namespace Contactos.Core.Services
{
    public class CorreoService : ICorreoService
    {
        private readonly IUnitOfWork work;

        public CorreoService(IUnitOfWork work)
        {
            this.work = work;
        }

        public IEnumerable<Correo> GetAll(int IdContacto)
        {
            var all = this.work.CorreoRepo.GetAll();
            return all.Where(e=>e.IdContacto == IdContacto);
        }

        public async Task<Correo> GetById(int id)
        {
            return await this.work.CorreoRepo.GetById(id);
        }

        public async Task<bool> Add(List<Correo> telefonos)
        {
            var row = 0;

            foreach (var item in telefonos)
            {
                item.IdEstatus = 1;
                item.FechaRegistro = DateTime.Now;

                await this.work.CorreoRepo.Add(item);
                row = await this.work.SaveChangesAsync();
            }

            return row > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await this.GetById(id);
            current.IdEstatus = 2;
            current.FeechaBaja = DateTime.Now;

            this.work.CorreoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }

        public async Task<bool> Update(Correo usuario)
        {
            var current = await this.GetById(usuario.Id);
            current.Email = usuario.Email;
            current.FechaModificacion = DateTime.Now;

            this.work.CorreoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }
    }
}
