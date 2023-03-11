using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        public OrderRepository(IOrderDataProvider dataProvider)
        {
            m_DataProvider = dataProvider;
        }

        public int Count()
        {
            return m_DataProvider.OrderCount();
        }
        public bool Add(Order order)
        {
            return m_DataProvider.Add(order);
        }
        public void Clear()
        {
            m_DataProvider.ClearOrders();
        }
        public bool Contains(Order order)
        {
            return m_DataProvider.Contains(order);
        }
        public ICollection<Order> GetAll()
        {
            return m_DataProvider.GetAllOrders();
        }
        public bool Remove(Order order)
        {
            return m_DataProvider.Remove(order);
        }
        public bool Update(Order item)
        {
            return m_DataProvider.Update(item);
        }
        public ICollection<OrderEvaluation> GetOrderEvaluations(OrderEvaluationFilterCriterias filterCriterias)
        {
            return m_DataProvider.GetOrderEvaluations(filterCriterias);
        }

        private readonly IOrderDataProvider m_DataProvider;
    }
}