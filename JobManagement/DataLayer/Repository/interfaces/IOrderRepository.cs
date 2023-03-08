using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public ICollection<OrderEvaluation> GetOrderEvaluations(OrderEvaluationFilterCriterias filterCriterias);
    }
}
