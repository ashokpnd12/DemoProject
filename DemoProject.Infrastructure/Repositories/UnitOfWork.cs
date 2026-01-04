using DemoProject.Domain.Interfaces;
using DemoProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Products = new ProductRepository(_dbContext);
            Categories = new CategoryRepository(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
