using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Remove(T entity);

        void RangeRemove(IEnumerable<T> entity);
    }
}
