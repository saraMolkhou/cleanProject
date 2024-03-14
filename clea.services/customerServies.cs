using clean.core.Entities;
using clean.core.Repositories;

namespace clean.services
{
    public class customerServies
    {
        private readonly ICustomerRepository _customerRepository;
        public customerServies(ICustomerRepository cR)
        {
            _customerRepository = cR;
        }
        public List<customer> GetAll()
        {
            return _customerRepository.GetList();
        }
        public customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }
        public async Task AddCustomerAsync(customer customer)
        {
            await _customerRepository.AddAsync(customer);
        }
















        public async Task UpdateCustomerAsync(customer customer, int id)
        {
           await _customerRepository.UpdateAsync(customer, id);
        }
    }
}