﻿using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using BulkyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        ApplicationDbContext db;
        public CategoryRepository( ApplicationDbContext _db) : base(_db )
        {
                db = _db;
        }

        public void Update(Category category)
        {
            db.categories.Update(category);
        }
    }
}
