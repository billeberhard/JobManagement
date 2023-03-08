using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IOrderDataProvider : IBaseDataProvider<Order>
    {
        int OrderCount();
        void ClearOrders();
        ICollection<Order> GetAllOrders();
        public ICollection<OrderEvaluation> GetOrderEvaluations(OrderEvaluationFilterCriterias filterCriterias);
    }
}
