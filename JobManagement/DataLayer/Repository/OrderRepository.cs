﻿using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;

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
        public bool Add(Order order)
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

        public ICollection<OrderEvaluation> GetOrderEvaluations(OrderEvaluationFilterCriterias filterCriterias)
        {
            return m_dataProvider.GetOrderEvaluations(filterCriterias);
        }


        private readonly IOrderDataProvider m_dataProvider;
    }
}