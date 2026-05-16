using Unitofwork.Model;

namespace Unitofwork.Repository.Interface
{
    public interface IOrderheaderrepository
    {
        Task Save(OrderHeader order);
    }
}
