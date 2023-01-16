using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IOrderDataProvider : IBaseDataProvider<Order>
    {
        int OrderCount { get; }
        void ClearOrders();
        Order? GetOrder(int id);
        List<Order> GetAllOrders();
    }
}
