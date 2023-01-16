using DataLayer.DataProvider;
using DataLayer.TransferObjects;
using System.Collections;
using System.Diagnostics;

namespace DataLayer.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ICustomerDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public int Count
        {
            get { return m_dataProvider.CustomerCount; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void Add(Customer customer)
        {
            if (!Contains(customer))
                m_dataProvider.Add(customer);
        }
        public void Clear()
        {
            m_dataProvider.ClearCustomers();
        }
        public bool Contains(Customer customer)
        {
            return m_dataProvider.Contains(customer);
        }
        public void CopyTo(Customer[] array, int arrayIndex)
        {
            List<Customer> customers = m_dataProvider.GetAllCustomers();
            Debug.Assert(arrayIndex + customers.Count < array.Length);

            int i = arrayIndex;

            foreach (Customer customer in customers)
                array[i++] = customer;
        }
        public Customer Get(int id)
        {
            Customer? customer = m_dataProvider.GetCustomer(id);
            Debug.Assert(customer != null);

            return customer;
        }
        public List<Customer> GetAll()
        {
            return m_dataProvider.GetAllCustomers();
        }
        public bool Remove(Customer customer)
        {
            return m_dataProvider.Remove(customer);
        }
        public IEnumerator<Customer> GetEnumerator()
        {
            return new RepositoryEnumertor<Customer>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        ICustomerDataProvider m_dataProvider;
    }
}
