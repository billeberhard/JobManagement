using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface ICustomerDataProvider : IBaseDataProvider<Customer>
    {
        int CustomerCount();
        void ClearCustomers();
        ICollection<Customer> GetAllCustomers();
    }
}
