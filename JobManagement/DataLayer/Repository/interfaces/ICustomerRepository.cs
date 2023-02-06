using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        ICollection<Order> GetAllOrders(Customer customer);
    }
}