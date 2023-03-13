using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class PositionRepository : IPositionRepository
    {
        public PositionRepository(IPositionDataProvider dataProvider)
        {
            m_DataProvider = dataProvider;
        }

        public int Count()
        {
            return m_DataProvider.PositionCount();
        }
        public bool Add(Position order)
        {
            return m_DataProvider.Add(order);
        }
        public void Clear()
        {
            m_DataProvider.ClearPositions();
        }
        public bool Contains(Position order)
        {
            return m_DataProvider.Contains(order);
        }
        public ICollection<Position> GetAll()
        {
            return m_DataProvider.GetAllPositions();
        }
        public bool Remove(Position order)
        {
            return m_DataProvider.Remove(order);
        }
        public bool Update(Position item)
        {
            return m_DataProvider.Update(item);
        }

        public ICollection<Position> Search(string searchingContext)
        {
            return m_DataProvider.SearchPositions(searchingContext);
        }

        private readonly IPositionDataProvider m_DataProvider;
    }
}
