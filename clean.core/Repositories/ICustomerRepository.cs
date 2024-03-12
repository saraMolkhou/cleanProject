using clean.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Repositories
{
    public interface ICustomerRepository
    {
        List<customer> GetList();
         customer GetById(int id);
        Task AddAsync(customer customer);
        Task UpdateAsync(customer customer, int id);
    }
}
