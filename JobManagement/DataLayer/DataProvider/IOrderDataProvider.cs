using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IOrderDataProvider : IBaseDataProvider<Order>
    {
        int OrderCount();
        void ClearOrders();
        List<Order> GetAllOrders();
    }
}
