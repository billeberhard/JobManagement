using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IPositionDataProvider : IBaseDataProvider<Position>
    {
        int PositionCount();
        void ClearPositions();
        List<Position> GetAllPositions();
    }
}
