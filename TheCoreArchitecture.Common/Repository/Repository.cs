using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace TheCoreArchitecture.Common.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private const bool TrueExpression = true;
        protected readonly DbContext Context;
        protected DbSet<T> DbSet;
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public async Task<T> Get(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await FindQueryable(predicate).ToListAsync();
        }

        public IQueryable<T> FindQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.OfType<T>();
            query = includes.Aggregate(query, (current, property) => current.Include(property));
            return query.Where(predicate);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await FindQueryable(predicate,includes).ToListAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var result = await Find(predicate, includes);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return await Find(x => TrueExpression, includes);
        }

        public T Add(T newEntity)
        {
            return DbSet.Add(newEntity).Entity;
        }

        public void Update(T entity)
        {
            var key = GetKeyValue(entity);

            Update(entity, key);
        }

        public void Update(T entity, object key)
        {
            var originalEntity = DbSet.Find(key);

            Update(originalEntity, entity);
        }

        public void Update(T originalEntity, T newEntity)
        {
            Context.Entry(originalEntity).CurrentValues.SetValues(newEntity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var objects = Find(predicate);
            foreach (var obj in objects.Result)
            {
                DbSet.Remove(obj);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public string GetKeyField(Type type)
        {
            var allProperties = type.GetProperties();

            var keyProperty = allProperties.SingleOrDefault(p => p.IsDefined(typeof(KeyAttribute)));

            return keyProperty?.Name;
        }

        public int GetNextKeySequence()
        {
            var query = DbSet.OfType<T>();
            var theLast = query.LastOrDefault();
            if (theLast == null) return 1;
            var key = theLast.GetType().GetProperties().FirstOrDefault(
                    p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            if (key != null)
            {
                var keyValue = key.GetValue(theLast, null).ToString();
                int.TryParse(keyValue, out int valueResult);
                return valueResult;
            }

            return 0;
        }

        public object GetKeyValue(T t)
        {
            var key =
                typeof(T).GetProperties().FirstOrDefault(
                    p => p.GetCustomAttributes(typeof(KeyAttribute), true).Length != 0);
            return key?.GetValue(t, null);
        }
        

        public async Task<bool> Contains(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }
    }
}
