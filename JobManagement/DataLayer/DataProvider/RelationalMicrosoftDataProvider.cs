using Castle.Core.Resource;
using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DataLayer.DataProvider
{
    internal class RelationalMicrosoftDataProvider : IDataProvider
    {
        public Customer Add(Customer customer)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(customer, context);
            return new Customer(addedEntity);
        }
        public bool Contains(Customer customer)
        {
            JobManagementContext context = new JobManagementContext();
            return GetEntity(customer, context) != null;
        }
        public bool Remove(Customer customer)
        {
            using JobManagementContext context = new JobManagementContext();
            var entity = GetEntity(customer, context);

            if (entity == null)
                return false;

            context.Remove(entity);
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
        public ICollection<Customer> GetAllCustomers()
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


        public Location Add(Location location)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(location, context);
            return new Location(addedEntity);
        }
        public bool Contains(Location location)
        {
            JobManagementContext context = new JobManagementContext();
            return GetEntity(location, context) != null;
        }
        public bool Remove(Location location)
        {
            using JobManagementContext context = new JobManagementContext();
            LocationEntity entity = GetEntity(location, context);

            if (entity == null)
                return false;

            if (entity.Customers.Count > 0)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }
        public int LocationCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Locations.Count();
        }
        public ICollection<Location> GetAllLocations()
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


        public Order Add(Order order)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(order, context);
            return new Order(addedEntity);
        }

        public bool Contains(Order order)
        {
            JobManagementContext context = new JobManagementContext();

            return GetEntity(order, context) != null;
        }
        public bool Remove(Order order)
        {
            using JobManagementContext context = new JobManagementContext();
            var entity = GetEntity(order, context);

            if (entity == null)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }
        public int OrderCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Orders.Count();
        }
        public ICollection<Position> GetAllPositionsOfOrder(Order order)
        {
            JobManagementContext context = new JobManagementContext();
            var positions = new List<Position>();
            var entity = GetEntity(order, context);

            if (entity == null)
                return positions;

            var positionEntitys = entity.Positions;
            foreach (PositionEntity e in positionEntitys)
                positions.Add(new Position(e));

            return positions;
        }
        public ICollection<Order> GetAllOrders()
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



        public Article Add(Article article)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(article, context);
            return new Article(addedEntity);
        }
        public bool Contains(Article article)
        {
            JobManagementContext context = new JobManagementContext();
            return GetEntity(article, context) != null;
        }
        public bool Remove(Article article)
        {
            using JobManagementContext context = new JobManagementContext();
            var entity = GetEntity(article, context);

            if (entity == null)
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
        public ICollection<Article> GetAllArticles()
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


        public ArticleGroup Add(ArticleGroup articleGroup)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(articleGroup, context);
            return new ArticleGroup(addedEntity);
        }
        public bool Contains(ArticleGroup articleGroup)
        {
            JobManagementContext context = new JobManagementContext();
            return GetEntity(articleGroup, context) != null;
        }
        public bool Remove(ArticleGroup articleGroup)
        {
            using JobManagementContext context = new JobManagementContext();
            var entity = GetEntity(articleGroup, context);

            if (entity == null)
                return false;

            if (entity.SubordinateArticleGroups.Count > 0)
                return false;

            context.Remove<ArticleGroupEntity>(entity);
            context.SaveChanges();
            return true;
        }
        public int ArticleGroupCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.ArticleGroups.Count();
        }
        public ICollection<ArticleGroup> GetAllArticleGroups()
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


        public Position Add(Position position)
        {
            var context = new JobManagementContext();
            var addedEntity = Add(position, context);
            return new Position(addedEntity);
        }
        public bool Contains(Position position)
        {
            JobManagementContext context = new JobManagementContext();
            return GetEntity(position, context) != null;
        }
        public bool Remove(Position position)
        {
            using JobManagementContext context = new JobManagementContext();
            var entity = GetEntity(position, context);

            if (entity == null)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }
        public int PositionCount()
        {
            using JobManagementContext context = new JobManagementContext();

            return context.Positions.Count();
        }
        public ICollection<Position> GetAllPositions()
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



        private static CustomerEntity Add(Customer customer, JobManagementContext context)
        {
            var entity = GetEntity(customer, context);

            if (entity != null)
                return entity;

            var locatoinEntity = Add(customer.Location, context);
            entity = customer.ConvertToEntity();
            entity.Location = locatoinEntity;

            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }
        private static LocationEntity Add(Location location, JobManagementContext context)
        {
            var entity = GetEntity(location, context);

            if (entity != null)
                return entity;

            entity = location.ConvertToEntity();
            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }
        private static OrderEntity Add(Order order, JobManagementContext context)
        {
            var entity = GetEntity(order, context);

            if (entity != null)
                return entity;

            var customerEntity = Add(order.Customer, context);
            entity = order.ConvertToEntity();
            entity.Customer = customerEntity;

            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }
        private static ArticleEntity Add(Article article, JobManagementContext context)
        {
            var entity = GetEntity(article, context);

            if (entity != null)
                return entity;

            var articleGroupEntity = Add(article.ArticleGroup, context);
            entity = article.ConvertToEntity();
            entity.ArticleGroup = articleGroupEntity;

            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }
        private static ArticleGroupEntity Add(ArticleGroup articleGroup, JobManagementContext context)
        {
            var entity = GetEntity(articleGroup, context);

            if (entity != null)
                return entity;

            entity = articleGroup.ConvertToEntity();

            if (articleGroup.SuperiorArticleGroup != null)
                entity.SuperiorArticleGroup = Add(articleGroup.SuperiorArticleGroup, context);

            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }
        private static PositionEntity Add(Position position, JobManagementContext context)
        {
            var entity = GetEntity(position, context);

            if (entity != null)
                return entity;

            var orderEntity = Add(position.Order, context);
            var articleEntity = Add(position.Article, context);
            entity = position.ConvertToEntity();
            entity.Order = orderEntity;
            entity.Article = articleEntity;

            var addedEntity = context.Add(entity).Entity;
            context.SaveChanges();

            return addedEntity;
        }


        private static CustomerEntity? GetEntity(Customer customer, JobManagementContext context)
        {
            if (customer == null || context == null)
                return null;

            if (customer.CustomerId != 0)
                return context.Set<CustomerEntity>().Where(x => x.CustomerId == customer.CustomerId).FirstOrDefault();

            foreach (CustomerEntity c in context.Customers)
                if (customer.DataEquals(new Customer(c)))
                    return c;

            return null;
        }
        private static LocationEntity? GetEntity(Location location, JobManagementContext context)
        {
            if (location == null || context == null)
                return null;

            if (location.LocationId != 0)
                return context.Set<LocationEntity>().Where(x => x.LocationId == location.LocationId).FirstOrDefault();

            foreach (LocationEntity l in context.Locations)
                if (location.DataEquals(new Location(l)))
                    return l;

            return null;
        }
        private static OrderEntity? GetEntity(Order order, JobManagementContext context)
        {
            if (order == null || context == null)
                return null;

            foreach (OrderEntity o in context.Orders)
                if (order.DataEquals(new Order(o)))
                    return o;

            return null;
        }
        private static ArticleEntity? GetEntity(Article article, JobManagementContext context)
        {
            if (article == null || context == null)
                return null; 
            
            foreach (ArticleEntity a in context.Articles)
                if (article.DataEquals(new Article(a)))
                    return a;

            return null;
        }
        private static ArticleGroupEntity? GetEntity(ArticleGroup articleGroup, JobManagementContext context)
        {
            if (articleGroup == null || context == null)
                return null;

            foreach (ArticleGroupEntity ag in context.ArticleGroups)
                if (articleGroup.DataEquals(new ArticleGroup(ag)))
                    return ag;

            return null;
        }
        private static PositionEntity? GetEntity(Position position, JobManagementContext context)
        {
            if (position == null || context == null)
                return null;

            foreach (PositionEntity p in context.Positions)
                if (position.DataEquals(new Position(p)))
                    return p;

            return null;
        }

    }
}