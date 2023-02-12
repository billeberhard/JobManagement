using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        ICollection<Position> GetAllPositions(Order order);
    }
}
