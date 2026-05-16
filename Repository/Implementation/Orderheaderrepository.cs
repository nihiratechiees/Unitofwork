using Unitofwork.Data;
using Unitofwork.Model;
using Unitofwork.Repository.Interface;

namespace Unitofwork.Repository.Implementation
{
    public class Orderheaderrepository:IOrderheaderrepository
    {
        private readonly TestDBContext _context;
        public Orderheaderrepository(TestDBContext context)
        {
            _context = context;
        }
       
        public async Task Save(OrderHeader order)
        {
           await _context.OrderHeaders.AddAsync(order);
        }
    }
}
