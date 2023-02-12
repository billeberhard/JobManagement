using DataLayer.DataProvider;
using DataLayer.TransferObjects;
using System.Diagnostics;

namespace DataLayer.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        public OrderRepository(IOrderDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public int Count()
        {
            return m_dataProvider.OrderCount();
        }
        public Order Add(Order order)
        {
            return m_dataProvider.Add(order);
        }
        public void Clear()
        {
            m_dataProvider.ClearOrders();
        }
        public bool Contains(Order order)
        {
            return m_dataProvider.Contains(order);
        }
        public ICollection<Order> GetAll()
        {
            return m_dataProvider.GetAllOrders();
        }
        public bool Remove(Order order)
        {
            return m_dataProvider.Remove(order);
        }

        public ICollection<Position> GetAllPositions(Order order)
        {
            return m_dataProvider.GetAllPositionsOfOrder(order);
        }


        private readonly IOrderDataProvider m_dataProvider;
    }
}