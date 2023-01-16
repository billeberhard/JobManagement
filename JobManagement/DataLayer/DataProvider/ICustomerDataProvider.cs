using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface ICustomerDataProvider : IBaseDataProvider<Customer>
    {
        int CustomerCount { get; }
        void ClearCustomers();
        Customer? GetCustomer(int id);
        List<Customer> GetAllCustomers();
    }
}
