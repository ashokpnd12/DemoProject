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
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }
    }
}
