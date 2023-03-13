using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IPositionDataProvider : IBaseDataProvider<Position>
    {
        int PositionCount();
        void ClearPositions();
        ICollection<Position> GetAllPositions();
        ICollection<Position> SearchPositions(string searchContext);
        ICollection<Position> GetAllPositionsOfOrder(Order order);
    }
}
