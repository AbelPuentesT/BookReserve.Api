using BookReserve.Core.Entities;
using BookReserve.Core.QueryFilters;
using BookReserve.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PolizaSOAT.Core.Interfaces;

namespace PolizaSOAT.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly BookReserveContext _context;
        protected readonly DbSet<T> _entities;
        public Repository(BookReserveContext polizaSoatContext)  
        {
            _context = polizaSoatContext;
            _entities = polizaSoatContext.Set<T>();
        }
        public  IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            var entity= await _entities.FindAsync(id);
            if(entity == null)
            {
                throw new Exception("Not Fount");
            }
            return entity;
        }
        public async Task Insert(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _entities.Update(entity);   
        }

        public async Task Delete(int id)
        {
            T entityToDelete = await GetById(id);
            _entities.Remove(entityToDelete);
        }
    }
}
