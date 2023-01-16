using DataLayer.DataProvider;
using DataLayer.TransferObjects;
using System.Collections;
using System.Diagnostics;

namespace DataLayer.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        public OrderRepository(IOrderDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public int Count
        {
            get { return m_dataProvider.OrderCount; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public void Add(Order order)
        {
            m_dataProvider.Add(order);
        }
        public void Clear()
        {
            m_dataProvider.ClearOrders();
        }
        public bool Contains(Order order)
        {
            return m_dataProvider.Contains(order);
        }
        public void CopyTo(Order[] array, int arrayIndex)
        {
            List<Order> orders = m_dataProvider.GetAllOrders();
            Debug.Assert(arrayIndex + orders.Count < array.Length);

            int i = arrayIndex;

            foreach(Order order in orders)
                array[i++] = order;
        }
        public Order Get(int id)
        {
            Order? order = m_dataProvider.GetOrder(id);
            Debug.Assert(order != null);
            
            return order;
        }
        public List<Order> GetAll()
        {
            return m_dataProvider.GetAllOrders();
        }
        public bool Remove(Order order)
        {
            return m_dataProvider.Remove(order);
        }
        public IEnumerator<Order> GetEnumerator()
        {
            return new RepositoryEnumertor<Order>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IOrderDataProvider m_dataProvider;
    }
}
