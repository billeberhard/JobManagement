using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface ILocationDataProvider : IBaseDataProvider<Location>
    {
        int LocationCount();
        void ClearLocations();
        List<Location> GetAllLocations();
    }
}
