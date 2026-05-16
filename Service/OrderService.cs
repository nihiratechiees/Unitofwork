using Unitofwork.Model;
using Unitofwork.Repository.Interface;

namespace Unitofwork.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitofWork _unitofWork;
        public OrderService(IUnitofWork unitofWork) {
            _unitofWork = unitofWork;
        }
        public async Task<string> SaveOrderasync(OrderRequest orderRequest)
        {
            if (orderRequest == null || !orderRequest.Items.Any())
            {
                throw new ArgumentException("Items required");
            }
            decimal TotalAmount = 0;
            var orderheader = new OrderHeader()
            {
                OrderId = Guid.NewGuid().ToString(),
                OrderDate = DateTime.Now,
                CustomerId = orderRequest.CustomerId,
                TotalAmount = TotalAmount
            };
          
            var orderitem=new List<OrderItem>();
            orderRequest.Items.ForEach(item =>
            {
                if (item.Quantity == null || item.UnitPrice == null)
                {
                    throw new ArgumentException("Quantity and Unitprice required");
                }
                if (item.Quantity <= 0 || item.UnitPrice <= 0)
                {
                    throw new ArgumentException("Quantity and Unitprice should be greater than zero");
                }
                var totalPrice = item.Quantity * item.UnitPrice;
                orderitem.Add(new OrderItem()
                {
                    OrderId=orderheader.OrderId,
                    ProductId=item.ProductId,
                    Quantity=item.Quantity,
                    UnitPrice=item.UnitPrice,
                    TotalPrice = totalPrice
                });
                TotalAmount += totalPrice;
            });
            orderheader.TotalAmount = TotalAmount;
            await _unitofWork._header.Save(orderheader);
            await _unitofWork._item.Save(orderitem);
            await _unitofWork.CompleteAsync();
            return orderheader.OrderId;
        }
    }
}
