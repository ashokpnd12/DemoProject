using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        /// <summary>
        /// Commits all changes across repositories in a single transaction.
        /// </summary>
        Task<int> SaveAsync();
    }
}
