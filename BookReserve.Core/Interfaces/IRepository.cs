using BookReserve.Core.Entities;
using BookReserve.Core.QueryFilters;

namespace PolizaSOAT.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
         IQueryable<T> GetAll();
        Task <T> GetById(int id);
        Task Insert(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
