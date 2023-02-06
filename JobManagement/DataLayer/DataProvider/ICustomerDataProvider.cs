using DataLayer.Model;
using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface ICustomerDataProvider : IBaseDataProvider<Customer>
    {
        int CustomerCount();
        void ClearCustomers();
        List<Customer> GetAllCustomers();
        ICollection<Order> GetAllOrdersOfCustomer(Customer customer);
    }
}
