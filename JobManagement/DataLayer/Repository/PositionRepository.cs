using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class PositionRepository : IPositionRepository
    {
        public PositionRepository(IPositionDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public int Count()
        {
            return m_dataProvider.PositionCount();
        }
        public Position Add(Position order)
        {
            return m_dataProvider.Add(order);
        }
        public void Clear()
        {
            m_dataProvider.ClearPositions();
        }
        public bool Contains(Position order)
        {
            return m_dataProvider.Contains(order);
        }
        public ICollection<Position> GetAll()
        {
            return m_dataProvider.GetAllPositions();
        }
        public bool Remove(Position order)
        {
            return m_dataProvider.Remove(order);
        }

        private readonly IPositionDataProvider m_dataProvider;
    }
}
