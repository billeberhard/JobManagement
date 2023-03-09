using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ICustomerDataProvider dataProvider)
        {
            m_DataProvider = dataProvider;
        }

        public int Count()
        {
            return m_DataProvider.CustomerCount();
        }
        public bool Add(Customer customer)
        {
            return m_DataProvider.Add(customer);
        }
        public void Clear()
        {
            m_DataProvider.ClearCustomers();
        }
        public bool Contains(Customer customer)
        {
            return m_DataProvider.Contains(customer);
        }
        public ICollection<Customer> GetAll()
        {
            return m_DataProvider.GetAllCustomers();
        }
        public bool Remove(Customer customer)
        {
            return m_DataProvider.Remove(customer);
        }

        public bool Update(Customer customer)
        {
            return m_DataProvider.Update(customer);
        }

        private readonly ICustomerDataProvider m_DataProvider;
    }
}
