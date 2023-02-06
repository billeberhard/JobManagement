using DataLayer.DataProvider;

namespace DataLayer.Repository
{
    public class DataRepository
    {
        public ICustomerRepository Customers { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IArticleRepository Articles { get; private set; }
        public IArticleGroupRepository ArticleGroups { get; private set; }
        public IPositionRepository Positions { get; private set; }

        public DataRepository()
        {
            IDataProvider dataProvider = new RelationalMicrosoftDataProvider();

            Customers = new CustomerRepository(dataProvider);
            Locations = new LocationRepository(dataProvider);
            Orders = new OrderRepository(dataProvider);
            Articles = new ArticleRepository(dataProvider);
            ArticleGroups = new ArticleGroupRepository(dataProvider);
            Positions = new PositionRepository(dataProvider);
        }
    }
}
