using clean.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Repositories
{
    public interface IProductRepository
    {
        List<product> GetList();
        product GetById(string barcode);
        Task AddAsync(product product);
        Task UpdateAsync(product prod, string barcode);
        Task RemoveAsync(string barcode);
    }
}
