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

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = category.Name;
            existingCategory.DisplayOrder = category.DisplayOrder;
            _dbContext.Categories.Update(existingCategory);
            return existingCategory;
        }

        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            _dbContext.Categories.Remove(category);
            return category;
        }
    }
}
