using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public class Repository
    {
        public ICustomerRepository Customers
        {
            get { return m_CustomerRepository; }
        }
        public IOrderRepository Orders
        {
            get { return m_OrderRepository; }
        }
        

        public Repository()
        {
            IDataProvider dataProvider = new MicrosoftSQL();

            m_CustomerRepository = new CustomerRepository(dataProvider);
            m_OrderRepository = new OrderRepository(dataProvider);
        }

        private IOrderRepository m_OrderRepository;
        private ICustomerRepository m_CustomerRepository;
    }
}
