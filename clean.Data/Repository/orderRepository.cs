using clean.core.Entities;
using clean.core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.Data.Repository
{
    public class orderRepository: IOrderRepository
    {
        private readonly DataContext _context;
        public orderRepository(DataContext context)
        {
            _context = context;
        }
        public List<order> GetList()
        {
            return _context.Orders.Include(o => o.customer).ToList();
        }

        public order GetById(int oNum)
        {
            foreach (order ord in _context.Orders)
            {
                if (ord.orderNum == oNum)
                    return ord;
            }
            return null;
        }
        public async Task AddAsync(order ord)
        {
            order new_order = new order { orderNum = ord.orderNum, Status = ord.Status, orderSum = ord.orderSum, orderDate = ord.orderDate , customerId=ord.customerId};
            _context.Orders.Add(new_order);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(order order, int oNum)
        {
            foreach (order ord in _context.Orders)
            {
                if (ord.orderNum == oNum)
                {
                    ord.Status = order.Status;
                    ord.orderNum = order.orderNum;
                    ord.orderSum = order.orderSum;
                    ord.orderDate = order.orderDate;
                   await _context.SaveChangesAsync();
                }

            }
        }
    }
}
