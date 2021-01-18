using Contactos.Core.Entities;
using Contactos.Core.Interfaces.Repositories;
using Contactos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DBCONTACTOSContext context;
        private readonly DbSet<T> _Entities;

        public BaseRepository( DBCONTACTOSContext context)
        {
            this.context = context;
            this._Entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this._Entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _Entities.FindAsync(id);
        }

        public async Task Add(T Entity)
        {
            await this._Entities.AddAsync(Entity);
        }

        public void Delete(T Entity)
        {
            this._Entities.Update(Entity);
        }

        public void Update(T Entity)
        {
            this._Entities.Update(Entity);
        }
    }
}
