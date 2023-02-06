using Castle.Core.Resource;
using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DataLayer.DataProvider
{
    internal class RelationalMicrosoftDataProvider : IDataProvider
    {
        public bool Add(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();

            Add(customer.Location);
            LocationEntity? locatoinEntity = GetEntity(customer.Location, context);
            CustomerEntity? customerEntity = GetEntity(customer, context);

            if (customerEntity != null)
                return false;

            customerEntity = customer.ConvertToEntity();
            customerEntity.Location = locatoinEntity;

            context.Add(customerEntity);
            context.SaveChanges();
            return true;
        }
        public bool Contains(Customer customer)
        {
            List<Customer> customers = GetAllCustomers();
            foreach (Customer c in customers)
                if (customer.Equals(c))
                    return true;

            return false;
        }
        public bool Remove(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(customer))
                return false;

            context.Customers.Remove(customer.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int CustomerCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Customers.Count();
        }
        public ICollection<Order> GetAllOrdersOfCustomer(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();

            List<Order> ordersOfCustomer = new List<Order>();

            CustomerEntity? customerEntity = GetEntity(customer, context);
            if (customerEntity == null)
                return ordersOfCustomer;

            ICollection<OrderEntity> orderEntities = customerEntity.Orders;

            foreach (OrderEntity o in orderEntities)
                ordersOfCustomer.Add(new Order(o));

            return ordersOfCustomer;
        }
        public List<Customer> GetAllCustomers()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Customer> customers = new List<Customer>();
            
            var entitys = context.Customers;
            foreach (CustomerEntity entity in entitys)
                customers.Add(new Customer(entity));

            return customers;
        }
        public void ClearCustomers()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Customers.ExecuteDelete();
            context.SaveChanges();
        }


        public bool Add(Location location)
        {
            using JobManagementContext context = new JobManagementContext();

            LocationEntity? locationEntity = GetEntity(location, context);
            if (locationEntity != null)
                return false;

            context.Locations.Add(location.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public bool Contains(Location location)
        {
            List<Location> locations = GetAllLocations();
            foreach (Location c in locations)
                if (location.Equals(c))
                    return true;

            return false;
        }
        public bool Remove(Location location)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(location))
                return false;

            LocationEntity locationEntity = GetEntity(location, context);

            context.Remove(locationEntity);
            context.SaveChanges();
            return true;
        }
        public int LocationCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Locations.Count();
        }
        public List<Location> GetAllLocations()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Location> locations = new List<Location>();

            var entitys = context.Locations;
            foreach (LocationEntity entity in entitys)
                locations.Add(new Location(entity));

            return locations;
        }
        public void ClearLocations()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Locations.ExecuteDelete();
            context.SaveChanges();
        }


        public bool Add(Order order)
        {
            using JobManagementContext context = new JobManagementContext();

            if (Contains(order))
                return false;

            OrderEntity orderEntity = order.ConvertToEntity();

            CustomerEntity? existingCustomer = GetEntity(order.Customer, context);

            if (existingCustomer != null)
                orderEntity.Customer = existingCustomer;

            context.Orders.Add(orderEntity);
            context.SaveChanges();
            return true;
        }
        public bool Contains(Order order)
        {
            JobManagementContext context = new JobManagementContext();

            return GetOrderEntity(order, context) != null;
        }
        public bool Remove(Order order)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(order))
                return false;

            context.Orders.Remove(order.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int OrderCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Orders.Count();
        }
        public List<Order> GetAllOrders()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Order> orders = new List<Order>();
            
            var entitys = context.Orders;
            foreach (OrderEntity entity in entitys)
                orders.Add(new Order(entity));
            
            return orders;
        }
        public void ClearOrders()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Orders.ExecuteDelete();
            context.SaveChanges();
        }



        public bool Add(Article article)
        {
            using JobManagementContext context = new JobManagementContext();

            ArticleEntity? articleEntity = GetEntity(article, context);
            if (articleEntity != null)
                return false;

            context.Articles.Add(article.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public bool Contains(Article article)
        {
            List<Article> articles = GetAllArticles();
            foreach (Article a in articles)
                if (article.Equals(a))
                    return true;

            return false;
        }
        public bool Remove(Article article)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(article))
                return false;

            context.Articles.Remove(article.ConvertToEntity());
            context.Remove<ArticleEntity>(article.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int ArticleCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Articles.Count();
        }
        public List<Article> GetAllArticles()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Article> articles = new List<Article>();

            var entitys = context.Articles;
            foreach (ArticleEntity entity in entitys)
                articles.Add(new Article(entity));

            return articles;
        }
        public void ClearArticles()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Articles.ExecuteDelete();
            context.SaveChanges();
        }


        public bool Add(ArticleGroup articleGroup)
        {
            using JobManagementContext context = new JobManagementContext();

            ArticleGroupEntity? articleGroupEntity = GetEntity(articleGroup, context);
            if (articleGroupEntity != null)
                return false;

            context.ArticleGroups.Add(articleGroup.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public bool Contains(ArticleGroup articleGroup)
        {
            List<ArticleGroup> articles = GetAllArticleGroups();
            foreach (ArticleGroup ag in articles)
                if (articleGroup.Equals(ag))
                    return true;

            return false;
        }
        public bool Remove(ArticleGroup articleGroup)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(articleGroup))
                return false;

            context.ArticleGroups.Remove(articleGroup.ConvertToEntity());
            context.Remove<ArticleGroupEntity>(articleGroup.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int ArticleGroupCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.ArticleGroups.Count();
        }
        public List<ArticleGroup> GetAllArticleGroups()
        {
            using JobManagementContext context = new JobManagementContext();

            List<ArticleGroup> articles = new List<ArticleGroup>();

            var entitys = context.ArticleGroups;
            foreach (ArticleGroupEntity entity in entitys)
                articles.Add(new ArticleGroup(entity));

            return articles;
        }
        public void ClearArticleGroups()
        {
            using JobManagementContext context = new JobManagementContext();

            context.ArticleGroups.ExecuteDelete();
            context.SaveChanges();
        }


        public bool Add(Position position)
        {
            using JobManagementContext context = new JobManagementContext();

            PositionEntity? positionEntity = GetEntity(position, context);
            if (positionEntity != null)
                return false;

            context.Positions.Add(position.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public bool Contains(Position position)
        {
            List<Position> positions = GetAllPositions();
            foreach (Position p in positions)
                if (position.Equals(p))
                    return true;

            return false;
        }
        public bool Remove(Position position)
        {
            using JobManagementContext context = new JobManagementContext();

            if (!Contains(position))
                return false;

            context.Positions.Remove(position.ConvertToEntity());
            context.Remove<PositionEntity>(position.ConvertToEntity());
            context.SaveChanges();
            return true;
        }
        public int PositionCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Articles.Count();
        }
        public List<Position> GetAllPositions()
        {
            using JobManagementContext context = new JobManagementContext();

            List<Position> positions = new List<Position>();

            var entitys = context.Positions;
            foreach (PositionEntity entity in entitys)
                positions.Add(new Position(entity));

            return positions;
        }
        public void ClearPositions()
        {
            using JobManagementContext context = new JobManagementContext();

            context.Positions.ExecuteDelete();
            context.SaveChanges();
        }



        private static CustomerEntity? GetEntity(Customer customer, JobManagementContext context)
        {
            if (customer == null || context == null)
                return null;

            foreach (CustomerEntity c in context.Customers)
                if (customer.Equals(new Customer(c)))
                    return c;

            return null;
        }
        private static LocationEntity? GetEntity(Location location, JobManagementContext context)
        {
            if (location == null || context == null)
                return null;

            foreach (LocationEntity l in context.Locations)
                if (location.Equals(new Location(l)))
                    return l;

            return null;
        }
        private static OrderEntity? GetOrderEntity(Order order, JobManagementContext context)
        {
            if (order == null || context == null)
                return null;

            foreach (OrderEntity o in context.Orders)
                if (order.Equals(new Order(o)))
                    return o;

            return null;
        }
        private static ArticleEntity? GetEntity(Article article, JobManagementContext context)
        {
            if (article == null || context == null)
                return null; 
            
            foreach (ArticleEntity a in context.Articles)
                if (article.Equals(new Article(a)))
                    return a;

            return null;
        }
        private static ArticleGroupEntity? GetEntity(ArticleGroup articleGroup, JobManagementContext context)
        {
            if (articleGroup == null || context == null)
                return null;

            foreach (ArticleGroupEntity ag in context.ArticleGroups)
                if (articleGroup.Equals(new ArticleGroup(ag)))
                    return ag;

            return null;
        }
        private static PositionEntity? GetEntity(Position position, JobManagementContext context)
        {
            if (position == null || context == null)
                return null;

            foreach (PositionEntity p in context.Positions)
                if (position.Equals(new Position(p)))
                    return p;

            return null;
        }
    }
}
