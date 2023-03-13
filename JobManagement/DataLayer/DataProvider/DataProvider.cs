using DataLayer.DataProvider.interfaces;
using DataLayer.Model;
using DataLayer.TransferObjects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer.DataProvider
{

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
            context.Address.ExecuteDelete();

            context.SaveChanges();
        }
        public bool Contains(Customer item)
        {
            var context = new JobManagementDbContext();

            if (item.Id == 0)
                return false;

            var entity = context.Customers.FirstOrDefault(e => e.Id == item.Id);

            if (entity == null)
                return false;

            return true;
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
        public bool Update(Customer item)
        {
            var context = new JobManagementDbContext();

            var entity = context.Customers.Where(e => e.Id == item.Id).FirstOrDefault();
            if (entity == null)
                return false;

            bool valueChanged = false;

            if (entity.FirstName != item.FirstName)
            {
                entity.FirstName = item.FirstName;
                valueChanged = true;
            }
            if (entity.LastName != item.LastName)
            {
                entity.LastName = item.LastName;
                valueChanged = true;
            }
            if (entity.EmailAddress != item.EmailAddress)
            {
                entity.EmailAddress = item.EmailAddress;
                valueChanged = true;
            }
            if (entity.WebsiteURL != item.WebsiteURL)
            {
                entity.WebsiteURL = item.WebsiteURL;
                valueChanged = true;
            }
            if (entity.Password != item.Password)
            {
                entity.Password = item.Password;
                valueChanged = true;
            }
            if (entity.Address.StreetName != item.StreetName)
            {
                entity.Address.StreetName = item.StreetName;
                valueChanged = true;
            }
            if (entity.Address.HouseNumber != item.HouseNumber)
            {
                entity.Address.HouseNumber = item.HouseNumber;
                valueChanged = true;
            }
            if (entity.Address.City != item.City)
            {
                entity.Address.City = item.City;
                valueChanged = true;
            }
            if (entity.Address.PostalCode != item.PostalCode)
            {
                entity.Address.PostalCode = item.PostalCode;
                valueChanged = true;
            }

            if (valueChanged)
                context.SaveChanges();

            return valueChanged;
        }
        ICollection<Customer> ICustomerDataProvider.SearchCustomers(string searchContext)
        {
            var context = new JobManagementDbContext();

            var filterCriteria = new SqlParameter("filterCriteria", searchContext);

            string sql = @"
                select c.Id AS Id, FirstName, LastName, StreetName, HouseNumber, City, PostalCode, EmailAddress, WebsiteURL, [Password]  from [dbo].[Customer] c
                INNER JOIN [dbo].[Address] a ON c.AddressId = a.Id
                    WHERE c.Id LIKE '%' + @filterCriteria + '%' OR
                    c.FirstName LIKE '%' + @filterCriteria + '%' OR
                    c.LastName LIKE '%' + @filterCriteria + '%' OR
                    a.StreetName LIKE '%' + @filterCriteria + '%' OR
                    a.HouseNumber LIKE '%' + @filterCriteria + '%' OR
                    a.City LIKE '%' + @filterCriteria + '%' OR
                    a.PostalCode LIKE '%' + @filterCriteria + '%' OR
                    c.EmailAddress LIKE '%' + @filterCriteria + '%' OR
                    c.WebsiteURL LIKE '%' + @filterCriteria + '%' OR
                    c.[Password] LIKE '%' + @filterCriteria + '%';
                ";

            var customers = context.FilteredCustomers.FromSqlRaw(sql, filterCriteria
                ).ToList();

            return customers;
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
        public ICollection<ArticleGroup> GetAllRootArticleGroups()
        {
            var context = new JobManagementDbContext();

            var entities = context.ArticleGroups.Where(a => a.SuperiorArticleGroup == null).ToList();

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

            if (item.Id == 0)
                return false;

            var entity = context.ArticleGroups.FirstOrDefault(e => e.Id == item.Id);

            if (entity == null)
                return false;

            return true;
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
        public bool Update(ArticleGroup item)
        {
            var context = new JobManagementDbContext();

            var entity = context.ArticleGroups.Where(e => e.Id == item.Id).FirstOrDefault();
            if (entity == null)
                return false;

            bool valueChanged = false;

            if (entity.Name != item.Name)
            {
                entity.Name = item.Name;
                valueChanged = true;
            }

            if (!(entity.SuperiorArticleGroup == null && item.SuperiorArticleGroup == null))
            {
                if (entity.SuperiorArticleGroup == null)
                    entity.SuperiorArticleGroup = GetEntity(item.SuperiorArticleGroup.ToEntity(), context);
                else if (item.SuperiorArticleGroup == null)
                    entity.SuperiorArticleGroup = null;

                valueChanged = true;
            }

            if (valueChanged)
                context.SaveChanges();

            return valueChanged;
        }
        public ICollection<ArticleGroup> SearchArticleGroups(string searchingContext)
        {
            throw new NotImplementedException();
        }
        public ICollection<HierarcicalArticleGroup> GetHirarcicalArticleGroups()
        {
            var context = new JobManagementDbContext();
            
            var hirarcicalArticleGroupEntities = context.HirarcicalArticleGroups
                .FromSqlRaw(
                    @"; WITH HirarcicalArticleGroupCTE AS
                    (
	                    Select a.Id AS [Id], a.Name AS [Name], a.SuperiorArticleGroupId AS [SuperiorArticleGroupId], 0 AS [Hierarchy]
	                    FROM [dbo].[ArticleGroup] a
	                    WHERE a.SuperiorArticleGroupId IS NULL

	                    UNION ALL

	                    SELECT a.Id AS [Id], a.Name AS [Name], h.Id AS [SuperiorArticleGroupId], Hierarchy + 1
	                    FROM HirarcicalArticleGroupCTE h
	                    INNER JOIN [dbo].[ArticleGroup] a
		                    ON h.Id = a.SuperiorArticleGroupId
                    )
                    SELECT * FROM HirarcicalArticleGroupCTE;
                    ").ToArray();

            return Convert(hirarcicalArticleGroupEntities);
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

            if (item.Id == 0)
                return false;

            var entity = context.Articles.FirstOrDefault(e => e.Id == item.Id);

            if (entity == null)
                return false;

            return true;
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
        public bool Update(Article item)
        {
            var context = new JobManagementDbContext();

            var entity = context.Articles.Where(e => e.Id == item.Id).FirstOrDefault();
            if (entity == null)
                return false;

            bool valueChanged = false;

            if (entity.Name != item.Name)
            {
                entity.Name = item.Name;
                valueChanged = true;
            }
            if (entity.Price != item.Price)
            {
                entity.Price = item.Price;
                valueChanged = true;
            }

            if (item.ArticleGroup == null || item.ArticleGroup.Id == 0)
                return false;
            if (entity.ArticleGroup.Id != item.ArticleGroup.Id)
            {
                entity.ArticleGroup = item.ArticleGroup.ToEntity();
                valueChanged = true;
            }

            if (valueChanged)
                context.SaveChanges();

            return valueChanged;
        }
        public ICollection<Article> SearchArticles(string searchingContext)
        {
            throw new NotImplementedException();
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

            if (item.Id == 0)
                return false;

            var entity = context.Orders.FirstOrDefault(e => e.Id == item.Id);

            if (entity == null)
                return false;

            return true;
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
        public bool Update(Order item)
        {
            var context = new JobManagementDbContext();

            var entity = context.Orders.Where(e => e.Id == item.Id).FirstOrDefault();
            if (entity == null)
                return false;

            bool valueChanged = false;

            if (entity.CreationDate != item.CreationDate)
            {
                entity.CreationDate = item.CreationDate;
                valueChanged = true;
            }

            if (item.Customer == null || item.Customer.Id == 0)
                return false;
            if (entity.Customer.Id != item.Customer.Id)
            {
                entity.Customer = item.Customer.ToEntity();
                valueChanged = true;
            }



            if (valueChanged)
                context.SaveChanges();

            return valueChanged;
        }
        public ICollection<Order> SearchOrders(string searchContext)
        {
            throw new NotImplementedException();
        }
        public ICollection<OrderEvaluation> GetOrderEvaluations(OrderEvaluationFilterCriterias filterCriterias)
        {
            var context = new JobManagementDbContext();

            var customerNumberFilterCriteria = new SqlParameter("customerNumberFilterCriteria", filterCriterias.CustomerNumber.ToString());
            var firstNameFilterCriteria = new SqlParameter("firstNameFilterCriteria", filterCriterias.FirstName == null ? "" : filterCriterias.FirstName);
            var lastNameFilterCriteria = new SqlParameter("lastNameFilterCriteria", filterCriterias.LastName == null ? "" : filterCriterias.LastName);
            var streetNameFilterCriteria = new SqlParameter("streetNameFilterCriteria", filterCriterias.StreetName == null ? "" : filterCriterias.StreetName);
            var houseNumberFilterCriteria = new SqlParameter("houseNumberFilterCriteria", filterCriterias.HouseNumber == null ? "" : filterCriterias.HouseNumber);
            var postalCodeFilterCriteria = new SqlParameter("postalCodeFilterCriteria", filterCriterias.PostalCode == null ? "" : filterCriterias.PostalCode);
            var cityFilterCriteria = new SqlParameter("cityFilterCriteria", filterCriterias.City == null ? "" : filterCriterias.City);
            var minCreationDateFilterCriteria = new SqlParameter("minCreationDateFilterCriteria", filterCriterias.MinCreationDate);
            var maxCreationDateFilterCriteria = new SqlParameter("maxCreationDateFilterCriteria", filterCriterias.MaxCreationDate);
            var orderNumberFilterCriteria = new SqlParameter("orderNumberFilterCriteria", filterCriterias.OrderNumber.ToString());
            var minTotalOrderPriceFilterCriteria = new SqlParameter("minTotalOrderPriceFilterCriteria", filterCriterias.MinTotalOrderPrice.ToString());
            var maxTotalOrderPriceFilterCriteria = new SqlParameter("maxTotalOrderPriceFilterCriteria", filterCriterias.MaxTotalOrderPrice.ToString());

            string totalOrderPriceCTE = @$";WITH TotalOrderPriceCTE AS
                (
	                SELECT
		                c.Id AS [CustomerNumber],
		                sum(p.Amount * a.Price) AS [TotalOrderPrice]

	                FROM [dbo].[Customer] c
	                INNER JOIN [dbo].[Order] o
		                ON c.Id = o.CustomerId
	                INNER JOIN [dbo].[Position] p
		                ON o.Id = p.OrderId
	                INNER JOIN [dbo].[Article] a
		                ON p.ArticleId = a.Id
	                GROUP BY c.Id
                ),
                OrderOverviewCTE AS
                (
	                SELECT
                        o.Id AS [Id],
		                c.Id AS [CustomerNumber],
		                c.FirstName AS [FirstName],
		                c.Lastname AS [LastName],
		                adr.StreetName AS [StreetName],
		                adr.HouseNumber AS [HouseNumber],
		                adr.PostalCode AS [PostalCode],
		                adr.City AS [City],
		                o.CreationDate AS [CreationDate],
		                o.Id AS [OrderNumber],
		                RANK() OVER (PARTITION BY c.Id, adr.Id ORDER BY adr.PeriodEnd DESC) AS [PropperAddressRank],
		                cost.[TotalOrderPrice] AS [TotalOrderPrice]
		
	                FROM [dbo].[Customer] c
	                INNER JOIN [dbo].[Order] o
		                ON c.Id = o.CustomerId
	                INNER JOIN [dbo].[Address] adr
		                ON c.AddressId = adr.Id AND o.CreationDate <= adr.PeriodEnd
	                INNER JOIN TotalOrderPriceCTE cost
		                ON cost.CustomerNumber = c.Id

	                WHERE (@customerNumberFilterCriteria = -1 OR c.Id = @customerNumberFilterCriteria)
                        AND c.FirstName LIKE '%' + @firstNameFilterCriteria + '%'
	                    AND c.LastName LIKE '%' + @lastNameFilterCriteria + '%'
	                    AND adr.StreetName LIKE '%' + @streetNameFilterCriteria + '%'
	                    AND adr.HouseNumber LIKE '%' + @houseNumberFilterCriteria + '%'
	                    AND adr.PostalCode LIKE '%' + @postalCodeFilterCriteria + '%'
	                    AND adr.City LIKE '%' + @cityFilterCriteria + '%'
	                    AND o.CreationDate >= @minCreationDateFilterCriteria AND o.CreationDate <= @maxCreationDateFilterCriteria
                        AND (@orderNumberFilterCriteria = -1 OR o.Id = @orderNumberFilterCriteria)
                        AND (@minTotalOrderPriceFilterCriteria = -1 OR TotalOrderPrice >= @minTotalOrderPriceFilterCriteria)
                        AND (@maxTotalOrderPriceFilterCriteria = -1 OR TotalOrderPrice >= @maxTotalOrderPriceFilterCriteria)


                )
                SELECT
                    [Id],
	                [CustomerNumber],
	                [FirstName],
	                [LastName],
	                [StreetName],
	                [HouseNumber],
	                [PostalCode],
	                [City],
	                [CreationDate],
	                [OrderNumber],
	                [TotalOrderPrice]

                FROM OrderOverviewCTE
                WHERE [PropperAddressRank] = 1;
                ";

            var orderEvaluationEntities = context.OrderEvaluationEntities.FromSqlRaw(
                totalOrderPriceCTE,
                    customerNumberFilterCriteria,
                    firstNameFilterCriteria,
                    lastNameFilterCriteria,
                    streetNameFilterCriteria,
                    houseNumberFilterCriteria,
                    postalCodeFilterCriteria,
                    cityFilterCriteria,
                    minCreationDateFilterCriteria,
                    maxCreationDateFilterCriteria,
                    orderNumberFilterCriteria,
                    minTotalOrderPriceFilterCriteria,
                    maxTotalOrderPriceFilterCriteria
                ).ToList();

            return Convert(orderEvaluationEntities);
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
        static private ICollection<HierarcicalArticleGroup> Convert(ICollection<HierarcicalArticleGroupEntity> entities)
        {
            ICollection<HierarcicalArticleGroup> result = new List<HierarcicalArticleGroup>();

            foreach (var e in entities)
                result.Add(new HierarcicalArticleGroup(e));

            return result;
        }
        static private ICollection<OrderEvaluation> Convert(ICollection<OrderEvaluationEntity> entities)
        {
            ICollection<OrderEvaluation> result = new List<OrderEvaluation>();

            foreach (var e in entities)
                result.Add(new OrderEvaluation(e));

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
        static private int GetId(OrderEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static private int GetId(ArticleEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static private int GetId(CustomerEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }
        static private int GetId(AddressEntity entity, JobManagementDbContext context)
        {
            var queriedEntity = GetEntity(entity, context);

            if (queriedEntity == null)
                return 0;

            return queriedEntity.Id;
        }

    }
}
