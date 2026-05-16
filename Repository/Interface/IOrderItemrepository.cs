using Unitofwork.Model;

namespace Unitofwork.Repository.Interface
{
    public interface IOrderItemrepository
    {
        Task Save(List<OrderItem> items);
    }
}
