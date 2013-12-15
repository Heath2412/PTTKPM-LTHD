using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T:class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetByID(object id);

        void Insert(T obj);

        void Delete(object id);

        void Delete(T objToDelete);

        void Update(T objToUpdate); 
    }
}
