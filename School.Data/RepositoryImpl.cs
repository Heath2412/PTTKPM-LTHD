using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using School.BLL;

namespace School.DAL
{
    public class RepositoryImpl<T> : IRepository<T> where T:class
    {
        SchoolContext context = new SchoolContext();
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetByID(object id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
        }

        public void Delete(object id)
        {
            Delete(GetByID(id));
        }

        public void Delete(T objToDelete)
        {
            if (context.Entry(objToDelete).State == EntityState.Detached)
                context.Set<T>().Attach(objToDelete);
            context.Set<T>().Remove(objToDelete);
        }

        public void Update(T objToUpdate)
        {
            context.Entry(objToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
