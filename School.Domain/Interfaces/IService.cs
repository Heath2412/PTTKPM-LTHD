using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.BLL.Interfaces
{
    public interface IService
    {
        T GetByID<T>(object id) where T : class;
        IEnumerable<T> Get<T>(
            System.Linq.Expressions.Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
            where T : class;
        void Create<T>(T obj) where T : class;
        void Update<T>(T objToUpdate) where T : class;
        void Delete<T>(object id) where T : class;
        void Delete<T>(T objToDelete) where T : class;
        void SaveChange();
    }
}
