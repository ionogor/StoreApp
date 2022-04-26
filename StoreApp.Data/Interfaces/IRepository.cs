using StoreApp.Common.Paginations;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void SaveChangeAsync();
      
        Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity;
       }
   
}





