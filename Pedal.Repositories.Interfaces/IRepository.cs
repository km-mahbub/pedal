using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal.Repositories.Interfaces
{
     public interface IRepository<TEntity>
     {
        List<TEntity> GetAll();
        TEntity Get<TKey>(TKey id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
     }
    
}
