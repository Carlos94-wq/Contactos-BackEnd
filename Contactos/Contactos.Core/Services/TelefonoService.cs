using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Core.Services
{
    public class TelefonoService : ITelefonoService
    {

        private readonly IUnitOfWork work;

        public TelefonoService(IUnitOfWork work)
        {
            this.work = work;
        }

        public IEnumerable<Telefono> GetAll(int IdContacto)
        {
            var all = this.work.TelefonoRepo.GetAll();
            return all.Where(e => e.IdContacto == IdContacto);
        }

        public async Task<Telefono> GetById(int id)
        {
            return await this.work.TelefonoRepo.GetById(id);
        }

        public async Task<bool> Add(List<Telefono> telefonos)
        {
            var row = 0;

            foreach (var item in telefonos)
            {
                item.IdEstatus = 1;
                item.FechaRegistro = DateTime.Now;

                await this.work.TelefonoRepo.Add(item);
                row = await this.work.SaveChangesAsync();
            }

            return row > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var current = await this.GetById(id);
            current.IdEstatus = 2;
            current.FeechaBaja = DateTime.Now;

            this.work.TelefonoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }

        public async Task<bool> Update(Telefono usuario)
        {
            var current = await this.GetById(usuario.Id);
            current.Numero = usuario.Numero;
            current.FechaModificacion = DateTime.Now;

            this.work.TelefonoRepo.Delete(current);

            var row = await this.work.SaveChangesAsync();

            return row > 0;
        }
    }
}
