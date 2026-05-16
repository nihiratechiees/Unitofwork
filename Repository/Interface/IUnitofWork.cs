namespace Unitofwork.Repository.Interface
{
    public interface IUnitofWork
    {
        IOrderheaderrepository _header { get; }
        IOrderItemrepository _item { get; }

        Task<int> CompleteAsync();

    }
}
