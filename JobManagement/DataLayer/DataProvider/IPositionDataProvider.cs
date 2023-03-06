using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IPositionDataProvider : IBaseDataProvider<Position>
    {
        int PositionCount();
        void ClearPositions();
        ICollection<Position> GetAllPositions();
        ICollection<Position> GetAllPositionsOfOrder(Order order);
    }
}
