using DemoProject.Domain.Interfaces;
using DemoProject.Domain.Models;
using DemoProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Infrastructure.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
