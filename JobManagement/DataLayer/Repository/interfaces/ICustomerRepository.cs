using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        bool Update(Customer customer);
    }
}