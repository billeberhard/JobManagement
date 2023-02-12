using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IOrderDataProvider : IBaseDataProvider<Order>
    {
        int OrderCount();
        void ClearOrders();
        ICollection<Order> GetAllOrders();
        ICollection<Position> GetAllPositionsOfOrder(Order order);
    }
}
