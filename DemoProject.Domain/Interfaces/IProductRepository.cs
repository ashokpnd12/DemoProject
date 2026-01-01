using DemoProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();
    }
}
