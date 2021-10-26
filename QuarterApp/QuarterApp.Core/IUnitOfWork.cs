using QuarterApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Core
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IPropertyRepository PropertyRepository { get; }

        Task<int> CommitAsync();
    }
}
