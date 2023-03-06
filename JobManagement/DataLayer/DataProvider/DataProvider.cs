using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataProvider
{
    internal interface IDataProvider : ICustomerDataProvider, IArticleGroupDataProvider, IArticleDataProvider, IOrderDataProvider
    { }

    internal class SQLDataProvider : IDataProvider
    {
        public bool Add(Customer item)
        {
            var context = new JobManagementDbContext();

            var entity = item.ToEntity();

            var addedEntity = Add(entity, context);
            if (addedEntity == null)
                return false;

            context.SaveChanges();
            if (item.Id == addedEntity.Id)
                return false;

            item.Id = addedEntity.Id;
            return true;
        }
        public void ClearCustomers()
        {
            var context = new JobManagementDbContext();

            context.Customers.ExecuteDelete();

            context.SaveChanges();
        }
        public bool Contains(Customer item)
        {
            var context = new JobManagementDbContext();
            var entity = item.ToEntity();

            return GetEntity(entity, context) != null;
        }
        public int CustomerCount()
        {
            var context = new JobManagementDbContext();

            return context.Customers.Count();
        }
        public ICollection<Customer> GetAllCustomers()
        {
            var context = new JobManagementDbContext();
            var entities = context.Customers.ToList();
            return Convert(entities);
        }
        public bool Remove(Customer item)
        {
            var context = new JobManagementDbContext();

            var entity = GetEntity(item.ToEntity(), context);
            if (entity == null)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }


        public int ArticleGroupCount()
        {
            var context = new JobManagementDbContext();

            return context.ArticleGroups.Count();
        }
        public void ClearArticleGroups()
        {
            var context = new JobManagementDbContext();

            context.ArticleGroups.ExecuteDelete();

            context.SaveChanges();
        }
        public ICollection<ArticleGroup> GetAllArticleGroups()
        {
            var context = new JobManagementDbContext();

            var entities = context.ArticleGroups.ToList();

            return Convert(entities);
        }
        public bool Add(ArticleGroup item)
        {
            var context = new JobManagementDbContext();

            var entity = item.ToEntity();
            var addedEntity = Add(entity, context);

            if (addedEntity == null)
                return false;

            context.SaveChanges();
            if (item.Id == addedEntity.Id)
                return false;

            item.Id = addedEntity.Id;
            return true;
        }
        public bool Contains(ArticleGroup item)
        {
            var context = new JobManagementDbContext();
            var entity = item.ToEntity();

            return GetEntity(entity, context) != null;
        }
        public bool Remove(ArticleGroup item)
        {
            var context = new JobManagementDbContext();
            var entity = GetEntity(item.ToEntity(), context);

            if (entity == null)
                return false;

            if (entity.SubordinateArticleGroups.Count != 0)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }


        public int ArticleCount()
        {
            var context = new JobManagementDbContext();

            return context.Articles.Count();
        }
        public void ClearArticles()
        {
            var context = new JobManagementDbContext();

            context.Articles.ExecuteDelete();

            context.SaveChanges();
        }
        public ICollection<Article> GetAllArticles()
        {
            var context = new JobManagementDbContext();

            var entities = context.Articles.ToList();

            return Convert(entities);
        }
        public bool Add(Article item)
        {
            var context = new JobManagementDbContext();

            var entity = item.ToEntity();
            var addedEntity = Add(entity, context);

            if (addedEntity == null)
                return false;

            context.SaveChanges();
            if (item.Id == addedEntity.Id)
                return false;

            item.Id = addedEntity.Id;
            return true;
        }
        public bool Contains(Article item)
        {
            var context = new JobManagementDbContext();
            var entity = item.ToEntity();

            return GetEntity(entity, context) != null;
        }
        public bool Remove(Article item)
        {
            var context = new JobManagementDbContext();
            var entity = GetEntity(item.ToEntity(), context);

            if (entity == null)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }


        public int OrderCount()
        {
            var context = new JobManagementDbContext();
            return context.Orders.Count();
        }
        public void ClearOrders()
        {
            var context = new JobManagementDbContext();

            context.Orders.ExecuteDelete();
            context.SaveChanges();
        }
        public ICollection<Order> GetAllOrders()
        {
            var context = new JobManagementDbContext();

            var entities = context.Orders.ToList();

            return Convert(entities);
        }
        public bool Add(Order item)
        {
            var context = new JobManagementDbContext();

            var entity = item.ToEntity();
            var addedEntity = Add(entity, context);

            if (addedEntity == null)
                return false;

            foreach (var p in item.Positions)
            {
                var positionEntity = p.ToEntity();
                positionEntity.Order = entity;
                Add(positionEntity, context);
            }

            context.SaveChanges();
            if (item.Id == addedEntity.Id)
                return false;

            item.Id = addedEntity.Id;
            return true;
        }
        public bool Contains(Order item)
        {
            var context = new JobManagementDbContext();
            var entity = item.ToEntity();
            return GetEntity(entity, context) != null;
        }
        public bool Remove(Order item)
        {
            var context = new JobManagementDbContext();
            var entity = GetEntity(item.ToEntity(), context);

            if (entity == null)
                return false;

            context.Remove(entity);
            context.SaveChanges();
            return true;
        }



        static private ICollection<Customer> Convert(ICollection<CustomerEntity> entities)
        {
            ICollection<Customer> result = new List<Customer>();

            foreach (var e in entities)
                result.Add(new Customer(e));

            return result;
        }
        static private ICollection<ArticleGroup> Convert(ICollection<ArticleGroupEntity> entities)
        {
            ICollection<ArticleGroup> result = new List<ArticleGroup>();

            foreach (var e in entities)
                result.Add(new ArticleGroup(e));

            return result;
        }
        static private ICollection<Article> Convert(ICollection<ArticleEntity> entities)
        {
            ICollection<Article> result = new List<Article>();

            foreach (var e in entities)
                result.Add(new Article(e));

            return result;
        }
        static private ICollection<Order> Convert(ICollection<OrderEntity> entities)
        {
            ICollection<Order> result = new List<Order>();

            foreach (var e in entities)
                result.Add(new Order(e));

            return result;
        }
        static private CustomerEntity Add(CustomerEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            entity.Address = Add(entity.Address, context);
            return context.Add(entity).Entity;
        }
        static private AddressEntity Add(AddressEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            return context.Add(entity).Entity;
        }
        static private ArticleEntity Add(ArticleEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            entity.ArticleGroup = Add(entity.ArticleGroup, context);
            return context.Add(entity).Entity;
        }
        static private ArticleGroupEntity Add(ArticleGroupEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            if (entity.SuperiorArticleGroup != null)
                entity.SuperiorArticleGroup = Add(entity.SuperiorArticleGroup, context);
            return context.Add(entity).Entity;
        }
        static private OrderEntity Add(OrderEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            entity.Customer = Add(entity.Customer, context);
            return context.Add(entity).Entity;
        }
        static private PositionEntity Add(PositionEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity != null)
                return queriedEntity;

            entity.Article = Add(entity.Article, context);
            entity.Order = Add(entity.Order, context);

            return context.Add(entity).Entity;
        }
        static private CustomerEntity? GetEntity(CustomerEntity entity, JobManagementDbContext context)
        {
            return context.Customers
                .Include(c => c.Address)
                .Where(e =>
                    e.FirstName == entity.FirstName &&
                    e.LastName == entity.LastName &&
                    e.EmailAddress == entity.EmailAddress &&
                    e.Address.StreetName == entity.Address.StreetName &&
                    e.Address.HouseNumber == entity.Address.HouseNumber &&
                    e.Address.City == entity.Address.City &&
                    e.Address.PostalCode == entity.Address.PostalCode &&
                    //e.Address.Id == GetId(entity, context) &&
                    e.WebsiteURL == entity.WebsiteURL &&
                    e.Password == entity.Password
                )
                .SingleOrDefault();
        }
        static private AddressEntity? GetEntity(AddressEntity entity, JobManagementDbContext context)
        {
            return context.Address
                .Where(e =>
                    e.StreetName == entity.StreetName &&
                    e.HouseNumber == entity.HouseNumber &&
                    e.City == entity.City &&
                    e.PostalCode == entity.PostalCode
                )
                .SingleOrDefault();
        }
        static private ArticleEntity? GetEntity(ArticleEntity entity, JobManagementDbContext context)
        {
            return context.Articles
                .Where(e =>
                    e.Name == entity.Name &&
                    e.Price == entity.Price
                )
                .SingleOrDefault();
        }
        static private ArticleGroupEntity? GetEntity(ArticleGroupEntity entity, JobManagementDbContext context)
        {
            return context.ArticleGroups
                .Where(e =>
                    e.Name == entity.Name
                )
                .SingleOrDefault();
        }
        static private OrderEntity? GetEntity(OrderEntity entity, JobManagementDbContext context)
        {
            return context.Orders
                .Where(e =>
                    e.CreationDate == entity.CreationDate &&
                    e.Customer.Id == GetId(entity.Customer, context)
                )
                .SingleOrDefault();
        }
        static private PositionEntity? GetEntity(PositionEntity entity, JobManagementDbContext context)
        {
            return context.Positions
                .Where(e =>
                    e.Amount == entity.Amount &&
                    e.Article.Id == GetId(entity.Article, context) &&
                    e.Order.Id == GetId(entity.Order, context)
                )
                .SingleOrDefault();
        }
        static int GetId(OrderEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static int GetId(ArticleEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static int GetId(CustomerEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static int GetId(AddressEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }


    }
}
