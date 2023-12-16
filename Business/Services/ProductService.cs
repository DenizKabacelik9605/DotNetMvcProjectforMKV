using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess.Models;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _product;

        public ProductService(IProductRepository product)
        {
            _product = product;
        }
        public async Task Add(Product model)
        {
           await _product.Add(model);
        }

        public async Task Delete(int id)
        {
            await _product.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _product.GetAll();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
           return await _product.GetById(id);
        }

        public async Task Update(Product model)
        {
             await _product.Update(model);
        }
    }
}
