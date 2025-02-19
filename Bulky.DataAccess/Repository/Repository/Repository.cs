using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAccess.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext db;
        DbSet<T> DbSet;
        public Repository(ApplicationDbContext _db)
        {
            db = _db;
            DbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> result = DbSet;
            result = result.Where(filter);
            return result.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> List = DbSet.ToList();
            return List;
        }

        public void RangeRemove(IEnumerable<T> entity)
        {
            
            DbSet.RemoveRange(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }
    }
}
