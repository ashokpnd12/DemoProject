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
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p=>p.Id == id);
            if (product == null)
                return null;
            _dbContext.Products.Remove(product);
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct == null)
                return null;

            existingProduct.Title = product.Title;
            existingProduct.ISBN = product.ISBN;
            existingProduct.Auther=product.Auther;
            existingProduct.ListPrice=product.ListPrice;
            existingProduct.Price=product.Price;
            existingProduct.Price50=product.Price50;
            existingProduct.Price100=product.Price100;
            existingProduct.Description=product.Description;
            _dbContext.Products.Update(existingProduct);
            return existingProduct;
        }
    }
}
