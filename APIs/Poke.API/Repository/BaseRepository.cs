using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poke.API.Data;
using Poke.API.Entities;
using Poke.API.Interfaces;

namespace Poke.API.Repository
{
    public class BaseRepository<T> : IRepository<T>  where T : BaseEntity
    {
        private readonly BalkanContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(BalkanContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _context.Remove(entity);
        }
    }
}