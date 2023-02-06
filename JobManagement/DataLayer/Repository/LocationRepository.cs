using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class LocationRepository : ILocationRepository
    {
        public LocationRepository(ILocationDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public bool Add(Location item)
        {
            return m_dataProvider.Add(item);
        }
        public void Clear()
        {
            m_dataProvider.ClearLocations();
        }
        public bool Contains(Location item)
        {
            return m_dataProvider.Contains(item);
        }
        public int Count()
        {
            return m_dataProvider.LocationCount();
        }
        public ICollection<Location> GetAll()
        {
            return m_dataProvider.GetAllLocations();
        }
        public bool Remove(Location item)
        {
            return m_dataProvider.Remove(item);
        }

        private readonly ILocationDataProvider m_dataProvider;
    }
}
