using Microsoft.EntityFrameworkCore;
using StoreApp.Common.Paginations;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Repository
{
    public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GlobalContext _context;

        public EfCoreRepository()
        {
        }

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

        public  IEnumerable<T> GetAll()
        {
            return  _context.Set<T>().ToList();
        }

    
        public async Task<T> GetById(int id)
        {
          
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id==id );

        }

        public async Task<T> GetByIdWithInclude<T>(int id, params Expression<Func<T, object>>[] includeProperties) where T : BaseEntity
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }


        public Task<IEnumerable<TEntity>> GettAllProductsAndNameCatalogs<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            var products = IncludeProperties(includeProperties);

            return (Task<IEnumerable<TEntity>>)products;
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

        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

       






    }
}
