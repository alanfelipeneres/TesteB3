using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Core.Context;
using TesteB3.Core.Repository;

namespace TesteB3.Core.BO.Base
{
    public class BaseBO<T> where T : class
    {
        private TesteB3dbContext _context;
        private Repository<T> _repo;

        public BaseBO(TesteB3dbContext context)
        {
            _context = context;
            _repo = new Repository<T>(_context);
        }

        public void Add(T entity)
        {
            _repo.Add(entity);
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public void SaveChanges()
        {
            _repo.SaveChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _repo.SaveChangesAsync();
        }

        public IQueryable<T> Search(Func<T, bool> predicate)
        {
            return _repo.Search(predicate);
        }

        public async Task<T[]> GetAll()
        {
            return await _repo.GetAll();
        }

        public T GetById(int id)
        {
            return _repo.GetById(id);
        }

        public T GetByIdNoTracking(int id)
        {
            return _repo.GetByIdNoTracking(id);
        }

        //Utilizado para obter registros que não serão alterados no contexo do EF
        public IQueryable<T> GetNoTracking(Func<T, bool> predicate)
        {
            return _repo.GetNoTracking(predicate);
        }
    }
}
