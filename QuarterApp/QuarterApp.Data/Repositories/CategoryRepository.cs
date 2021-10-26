using QuarterApp.Core.Entities;
using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context):base(context)
        {
            _context = context;
        }
    }
}
