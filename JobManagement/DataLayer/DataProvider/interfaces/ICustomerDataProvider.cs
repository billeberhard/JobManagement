using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface ICustomerDataProvider : IBaseDataProvider<Customer>
    {
        int CustomerCount();
        void ClearCustomers();
        ICollection<Customer> GetAllCustomers();
        ICollection<Customer> SearchCustomers(string searchContext);
    }
}
