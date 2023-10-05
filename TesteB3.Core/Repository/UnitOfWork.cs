using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Core.Context;

namespace TesteB3.Core.Repository
{
    public class UnitOfWork
    {
        private bool _disposed;
        private TesteB3dbContext _context;

        public TesteB3dbContext Context
        {
            get { return _context; }
        }

        public UnitOfWork()
        {
            _context = new TesteB3dbContext(new DbContextOptions<TesteB3dbContext>());
        }

        public UnitOfWork(TesteB3dbContext TesteB3dbContext)
        {
            _context = TesteB3dbContext;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
