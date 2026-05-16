using Unitofwork.Model;

namespace Unitofwork.Service
{
    public interface IOrderService
    {
        Task<string> SaveOrderasync(OrderRequest orderRequest);
    }
}
