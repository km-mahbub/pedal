using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
     public interface IRepository<TEntity>
     {
         TEntity Get<TKey> (TKey id);
         IEnumerable<TEntity> GetAll();
         IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        
         TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

         void Add(TEntity entity);
         void AddRange(IEnumerable<TEntity> entities);

         void Remove(TEntity entity);
         void RemoveRange(IEnumerable<TEntity> entities);
     }
    
}
