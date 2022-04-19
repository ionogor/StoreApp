using Microsoft.EntityFrameworkCore;
using StoreApp.Common.Paginations;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Repository
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GlobalContext _context;

        public EfCoreRepository(GlobalContext globalContext)
        {
            _context=globalContext;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRangeAsync(entities);
            _context.SaveChanges();
        }

        public void Delete(T enti)
        {
            _context.Set<T>().Remove(enti);
            _context.SaveChanges();

        }

        public async Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id==id );

        }


        public void SaveChangeAsync()
        {
            _context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

       
        


    }
}
