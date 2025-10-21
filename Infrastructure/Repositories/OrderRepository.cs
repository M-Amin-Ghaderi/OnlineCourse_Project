using Domain.Interfaces;
using OnlineCourse_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
