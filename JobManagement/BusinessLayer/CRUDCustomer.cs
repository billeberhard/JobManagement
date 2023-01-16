using DataLayer.Repository;
using DataLayer.TransferObjects;

namespace BusinessLayer
{
    public class CRUDCustomer
    {
        public Customer GetCustomerData()
        {
            Repository r = new Repository();
            return r.Customers.GetAll()[0];
        }
    }
}
