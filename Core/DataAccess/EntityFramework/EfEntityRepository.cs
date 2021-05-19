using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity<int>, new()
        where TContext : DbContext, new()

    {

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            using(var _context = new TContext())
            {
                return predicate == null
                    ? _context.Set<TEntity>().ToList()
                    : _context.Set<TEntity>().Where(predicate).ToList();
            }
        }



        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            using(var _context = new TContext())
            {
                return _context.Set<TEntity>().FirstOrDefault(predicate);
            }
        }



        public void Add(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
        }



        public void AddRange(List<TEntity> entities)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().AddRange(entities);
                _context.SaveChanges();
            }
        }

    

        public void Remove(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
        }



        public void RemoveRange(List<TEntity> entities)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().RemoveRange(entities);
                _context.SaveChanges();
            }
        }



        public void Update(TEntity entity)
        {
            using (var _context = new TContext())
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
            }
        }
    }
}
