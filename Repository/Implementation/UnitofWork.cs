using Unitofwork.Data;
using Unitofwork.Repository.Interface;

namespace Unitofwork.Repository.Implementation
{
    public class UnitofWork : IUnitofWork
    {
        public IOrderheaderrepository _header { get; }

        public IOrderItemrepository _item { get; }
        private readonly TestDBContext _dbContext;
        public UnitofWork(IOrderheaderrepository orderheaderrepository,IOrderItemrepository orderItemrepository,
            TestDBContext testDB) { 
          _header = orderheaderrepository;
            _item = orderItemrepository;
            _dbContext = testDB;
        }
        

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
