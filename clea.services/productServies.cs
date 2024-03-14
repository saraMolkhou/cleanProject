using clean.core.Entities;
using clean.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.services
{
    public class productServies
    {
        private readonly IProductRepository _productRepository;
        public productServies(IProductRepository pR)
        {
           _productRepository = pR;
        }
        public List<product> GetAll()
        {
            return _productRepository.GetList();
        }
        public product GetProductById(string barcode)
        {
            return _productRepository.GetById(barcode);
        }
        public async Task AddProductAsync(product prod)
        {
          await  _productRepository.AddAsync(prod);
        }
        public async Task UpdateProductAsync(product prod, string barcode)
        {
           await _productRepository.UpdateAsync(prod, barcode);
        }
        public async Task DeleteProductAsync(string barcode)
        {
           await _productRepository.RemoveAsync(barcode);
        }
    }
}
