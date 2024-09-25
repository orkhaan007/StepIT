﻿using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstraction;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddAsync(Product product)
        {
            await _productDal.Add(product);
        }

        public async Task DeleteAsync(int id)
        {
            var item=await _productDal.Get(p=>p.ProductId==id);
            await _productDal.Delete(item);
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _productDal.GetList();
        }

        public Task<List<Product>> GetAllByCategoryAsync(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryId==categoryId || categoryId==0);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productDal.Get(p=>p.ProductId == id);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productDal.Update(product);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string query, int category)
        {
            var products = await GetAllByCategoryAsync(category);
            if (!string.IsNullOrEmpty(query))
            {
                products = products.Where(p => p.ProductName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return products;
        }

    }
}
