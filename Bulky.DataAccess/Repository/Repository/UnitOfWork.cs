using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using BulkyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext ApplicationDbContext;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext) 
        {
            ApplicationDbContext = applicationDbContext;
            // we are creating a new instance dispite we are having DI mapped because there may be multiplre classes and we cannot paas everything in constructor
            Category = new CategoryRepository(ApplicationDbContext);
        }
       

        public void Save()
        {
            ApplicationDbContext.SaveChanges();
        }
    }
}
