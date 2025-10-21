using Domain.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}
