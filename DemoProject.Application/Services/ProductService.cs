using DemoProject.Domain.Interfaces;
using DemoProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Application.Services
{
    public class ProductService
    {
        //private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _unitOfWork.Products.GetAllProductAsync();
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await _unitOfWork.Products.GetProductByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return null;
            }
            await _unitOfWork.Products.AddProductAsync(product);
            await _unitOfWork.SaveAsync();
            return product;
        }

        public async Task<Product> UpdateProductSync(Product product)
        {
            var existingProduct = await _unitOfWork.Products.UpdateProductAsync(product);
            if (existingProduct == null)
            {
                return null;
            }
            await _unitOfWork.SaveAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var deletedProduct = await _unitOfWork.Products.DeleteProductAsync(id);
            if (deletedProduct == null)
            {
                return false;
            }
            await _unitOfWork.SaveAsync();
            return true;
        }
    }
}
