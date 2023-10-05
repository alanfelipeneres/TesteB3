using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteB3.Core.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        IQueryable<T> Search(Func<T, bool> predicate);
        Task<T[]> GetAll();
        T GetById(int id);
        T GetByIdNoTracking(int id);
        IQueryable<T> GetNoTracking(Func<T, bool> predicate);
    }
}
