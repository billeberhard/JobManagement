using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    internal class OrderRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_ExpectedCount()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            int expectedCount = 0;

            repo.Orders.Add(order);

            // act
            repo.Orders.Clear();

            // assert
            int count = repo.Orders.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_ExpectedCount()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            int expectedCount = 1;

            // act
            repo.Orders.Add(order);

            // assert
            int count = repo.Orders.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_IdUpdated()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            int idBefore = order.Id;

            // act
            repo.Orders.Add(order);

            // assert
            int idAfter = order.Id;
            Assert.That(idBefore, Is.EqualTo(0));
            Assert.That(idAfter, Is.Not.EqualTo(0));
        }

        [Test]
        public void Add_BaseOperation_ReturnTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            // act
            bool added = repo.Orders.Add(order);

            // assert
            Assert.That(added, Is.True);
        }

        [Test]
        public void Add_AddingSameTwice_ReturnFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            repo.Orders.Add(order);
            // act
            bool added = repo.Orders.Add(order);

            // assert
            Assert.That(added, Is.False);
        }

        [Test]
        public void Add_AddingSameOrderWithDifferentPositionsTwice_ReturnFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article1 = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Article article2 = new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle };
            Position position1 = new Position() { Article = article1, Amount = 17 };
            Position position2 = new Position() { Article = article2, Amount = 3 };
            order.Positions.Add(position1);


            repo.Orders.Add(order);
            // act
            order.Positions.Add(position2);
            bool added = repo.Orders.Add(order);

            // assert
            Assert.That(added, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_ExpectedCount()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            int expectedCount = 0;
            repo.Orders.Add(order);

            // act
            repo.Orders.Remove(order);

            // assert
            int count = repo.Orders.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_ReturnsTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };

            repo.Orders.Add(order);

            // act
            bool contains = repo.Orders.Contains(order);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_ReturnsFalse()
        {
            // arrange
            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };

            DateTime date1 = new DateTime(2023, 01, 01, 12, 00, 00);
            DateTime date2 = new DateTime(2023, 01, 02, 14, 30, 00);
            DateTime date3 = new DateTime(2023, 01, 03, 16, 45, 00);

            Order order1 = new Order() { CreationDate = date1, Customer = customer1 };
            Order order2 = new Order() { CreationDate = date2, Customer = customer2 };
            Order order3 = new Order() { CreationDate = date3, Customer = customer3 };

            repo.Orders.Add(order1);
            repo.Orders.Add(order2);

            // act
            bool contains = repo.Orders.Contains(order3);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Count_BaseOperation_ExpectedCount()
        {
            // arrange
            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };

            DateTime date1 = new DateTime(2023, 01, 01, 12, 00, 00);
            DateTime date2 = new DateTime(2023, 01, 02, 14, 30, 00);
            DateTime date3 = new DateTime(2023, 01, 03, 16, 45, 00);

            Order order1 = new Order() { CreationDate = date1, Customer = customer1 };
            Order order2 = new Order() { CreationDate = date2, Customer = customer2 };
            Order order3 = new Order() { CreationDate = date3, Customer = customer3 };

            repo.Orders.Add(order1);
            repo.Orders.Add(order2);
            repo.Orders.Add(order3);

            int expectedCount = 3;

            // act
            int count = repo.Orders.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetAll_BaseOperation_CorrectCount()
        {
            // arrange
            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };

            DateTime date1 = new DateTime(2023, 01, 01, 12, 00, 00);
            DateTime date2 = new DateTime(2023, 01, 02, 14, 30, 00);
            DateTime date3 = new DateTime(2023, 01, 03, 16, 45, 00);

            Order order1 = new Order() { CreationDate = date1, Customer = customer1 };
            Order order2 = new Order() { CreationDate = date2, Customer = customer2 };
            Order order3 = new Order() { CreationDate = date3, Customer = customer3 };

            repo.Orders.Add(order1);
            repo.Orders.Add(order2);
            repo.Orders.Add(order3);

            int expectedCount = 3;

            // act
            ICollection<Order> returnedArticles = repo.Orders.GetAll();

            // assert
            int count = returnedArticles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetAll_GetNoElements_CorrectCount()
        {
            // arrange
            int expectedCount = 0;

            // act
            ICollection<Order> returnedArticles = repo.Orders.GetAll();

            // assert
            int count = returnedArticles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Update_BaseOperation_ReturnTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };
            repo.Orders.Add(order);

            // act
            order.CreationDate = new DateTime(2020, 01, 01, 12, 00, 00);
            bool updated = repo.Orders.Update(order);

            // assert
            Assert.That(updated, Is.True);
        }

        [Test]
        public void Update_BaseOperation_ValuesChanged()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime creationDate = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = creationDate, Customer = customer };
            repo.Orders.Add(order);


            Customer expectedCustomer = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            repo.Customers.Add(expectedCustomer);
            DateTime expectedCreationDate = new DateTime(2023, 01, 02, 14, 30, 00);

            // act
            order.CreationDate = expectedCreationDate;
            order.Customer = expectedCustomer;

            repo.Orders.Update(order);

            // assert
            var changedOrder = repo.Orders.GetAll().First();

            Assert.AreEqual(expectedCreationDate, changedOrder.CreationDate);
            Assert.AreEqual(expectedCustomer.Id, changedOrder.Customer.Id);
        }

        [Test]
        public void Update_AddingPosition_PositionGotAdded()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime creationDate = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = creationDate, Customer = customer };
            repo.Orders.Add(order);

            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Position expectedPosition = new Position() { Article = article, Amount = 17 };

            // act
            order.Positions.Add(expectedPosition);
            repo.Orders.Update(order);

            // assert
            var changedOrder = repo.Orders.GetAll().First();
            var addedPosition = changedOrder.Positions.Where(p => p.Id == expectedPosition.Id).FirstOrDefault();
            Assert.That(addedPosition, Is.Not.EqualTo(null));
        }

        [Test]
        public void Update_RemovingPosition_PositionGotRemoved()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime creationDate = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = creationDate, Customer = customer };

            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Position position = new Position() { Article = article, Amount = 17 };
            order.Positions.Add(position);
            repo.Orders.Add(order);

            // act
            order.Positions.Remove(position);
            repo.Orders.Update(order);

            // assert
            var changedOrder = repo.Orders.GetAll().First();
            var removedPosition = changedOrder.Positions.Where(p => p.Id == position.Id);

            Assert.That(removedPosition, Is.EqualTo(null));
        }

        [Test]
        public void Update_UpdatingPosition_PositionGotUpdated()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime creationDate = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = creationDate, Customer = customer };

            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Position position = new Position() { Article = article, Amount = 17 };
            order.Positions.Add(position);
            repo.Orders.Add(order);

            var changedAmount = 3;

            // act
            position.Amount = changedAmount;
            repo.Orders.Update(order);

            // assert
            var changedOrder = repo.Orders.GetAll().First();
            var changedPosition = changedOrder.Positions.Where(p => p.Id == position.Id).FirstOrDefault();

            Assert.AreEqual(changedAmount, changedPosition.Amount);
        }

        [Test]
        public void Update_CustomerNotExisting_ReturnFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime creationDate = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = creationDate, Customer = customer };
            repo.Orders.Add(order);

            // act
            order.Customer = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            bool changed = repo.Orders.Update(order);

            // assert
            Assert.That(changed, Is.False);
        }

        [Test]
        public void Update_NoChangesAreMade_ReturnFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            DateTime date = new DateTime(2023, 01, 01, 12, 00, 00);
            Order order = new Order() { CreationDate = date, Customer = customer };
            repo.Orders.Add(order);

            // act
            bool updated = repo.Orders.Update(order);

            // assert
            Assert.That(updated, Is.False);
        }
    }
}
