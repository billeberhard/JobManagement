using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ICustomerDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public int Count()
        {
            return m_dataProvider.CustomerCount();
        }
        public bool Add(Customer customer)
        {
            return m_dataProvider.Add(customer);
        }
        public void Clear()
        {
            m_dataProvider.ClearCustomers();
        }
        public bool Contains(Customer customer)
        {
            return m_dataProvider.Contains(customer);
        }
        public ICollection<Customer> GetAll()
        {
            return m_dataProvider.GetAllCustomers();
        }
        //public ICollection<Order> GetAllOrders(Customer customer)
        //{
        //    return m_dataProvider.GetAllOrdersOfCustomer(customer);
        //}
        public bool Remove(Customer customer)
        {
            return m_dataProvider.Remove(customer);
        }

        private readonly ICustomerDataProvider m_dataProvider;
    }
}
