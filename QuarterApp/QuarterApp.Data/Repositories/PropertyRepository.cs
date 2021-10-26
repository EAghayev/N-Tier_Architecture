using QuarterApp.Core.Entities;
using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Data.Repositories
{
    public class PropertyRepository:Repository<Property>, IPropertyRepository
    {
        private readonly DataContext _context;

        public PropertyRepository(DataContext context):base(context)
        {
            _context = context;
        }
    }
}
