using DemoProject.Domain.Interfaces;
using DemoProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Application.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _unitOfWork.Categories.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetCategoriesAsync(int id)
        {
            return await _unitOfWork.Categories.GetCategoryByIdAsync(id);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _unitOfWork.Categories.AddCategoryAsync(category);
            await _unitOfWork.SaveAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var updatedCategory = await _unitOfWork.Categories.UpdateCategoryAsync(category);
            if (updatedCategory == null)
            {
                return null; // category not found
            }
            await _unitOfWork.SaveAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deletedCategory = await _unitOfWork.Categories.DeleteCategoryAsync(id);
            if (deletedCategory == null)
                return false;
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
