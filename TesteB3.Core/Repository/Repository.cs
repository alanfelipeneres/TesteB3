using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Core.Context;

namespace TesteB3.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public TesteB3dbContext _context { get; }

        public Repository(TesteB3dbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //Obter registros com base em "cláusula" linq
        public IQueryable<T> Search(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).AsQueryable();
        }

        public async Task<T[]> GetAll()
        {
            var query = _context.Set<T>();
            return await query.ToArrayAsync();
        }

        public T GetById(int id)
        {
            var query = _context.Set<T>().Find(id);
            return query;
        }

        public T GetByIdNoTracking(int id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        //Utilizado para obter registros que não serão alterados no contexo do EF
        public IQueryable<T> GetNoTracking(Func<T, bool> predicate)
        {
            var query = _context.Set<T>().AsNoTracking().Where(predicate).AsQueryable();
            return query;
        }
    }
}
