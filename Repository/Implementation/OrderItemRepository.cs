using Unitofwork.Data;
using Unitofwork.Model;
using Unitofwork.Repository.Interface;

namespace Unitofwork.Repository.Implementation
{
    public class OrderItemRepository:IOrderItemrepository
    {
        private readonly TestDBContext _context;
        public OrderItemRepository(TestDBContext context)
        {
            _context = context;
        }

        public async Task Save(List<OrderItem> items)
        {
            await _context.OrderItems.AddRangeAsync(items);
        }

    }
}
