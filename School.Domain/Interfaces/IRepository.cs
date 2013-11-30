using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetByID(object id);

        void Insert(T obj);

        void Delete(object id);

        void Delete(T objToDelete);

        void Update(T objToUpdate);

        void Save();
    }
}
