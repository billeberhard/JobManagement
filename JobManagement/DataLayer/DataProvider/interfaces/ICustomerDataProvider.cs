using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface ICustomerDataProvider : IBaseDataProvider<Customer>
    {
        int CustomerCount();
        void ClearCustomers();
        ICollection<Customer> GetAllCustomers();
        bool Update(Customer item);
    }
}
