using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal.Data;
using System.Data.Entity;

namespace Pedal.Repositories
{
    public abstract class Repository<TEntity> where TEntity:class
    {

        internal PedalDbContext _context = new PedalDbContext();

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Get<TKey>(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public bool Insert(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Added;
            return _context.SaveChanges() > 0;
        }

        public bool Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
    }
}
