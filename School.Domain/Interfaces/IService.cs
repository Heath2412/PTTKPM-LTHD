using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL
{
    public interface IService<T>
    {
        T GetByID(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Create(T obj);
        void Update(T objToUpdate);
        void Delete(object id);
        void Delete(T objToUpdate);
    }
}
