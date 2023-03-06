using DataLayer.TransferObjects;
using NUnit.Framework;



namespace DataLayerTests
{
    [TestFixture]
    public class CustomerRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_NoElements()
        {
            // arrange
            AddAll(GetSampleCustomers());
            const int expectedCount = 0;

            // act
            repo.Customers.Clear();
            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Count_AddingItems_ExpectedAmount()
        {
            // arrange
            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };

            int expectedCount = 3;

            // act
            repo.Customers.Add(customer1);
            repo.Customers.Add(customer2);
            repo.Customers.Add(customer3);


            // assert
            int count = repo.Customers.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_IdGotUpdated()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            int previousId = customer.Id;

            // act

            repo.Customers.Add(customer);
            int newId = customer.Id;

            // assert
            Assert.That(previousId, Is.EqualTo(0));
            Assert.That(newId, Is.Not.EqualTo(0));
        }

        [Test]
        public void Add_BaseOperation_ReturnTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };

            // act
            bool added = repo.Customers.Add(customer);

            // assert
            Assert.That(added, Is.True);
        }

        [Test]
        public void Add_AddingSameTwice_ReturnFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            repo.Customers.Add(customer);

            // act
            bool added = repo.Customers.Add(customer);

            // assert
            Assert.That(added, Is.False);
        }

        [Test]
        public void Add_AddingSameTwice_OnlyOneAdded()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            int expectedCount = 1;

            repo.Customers.Add(customer);

            // act
            repo.Customers.Add(customer);

            // assert
            int count = repo.Customers.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingOverOrder_expectedCount()
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
            order.Positions.Add(position2);

            int expectedCount = 1;

            // act
            repo.Orders.Add(order);

            // assert
            int count = repo.Customers.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_ReturnsTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };


            repo.Customers.Add(customer);

            // act
            bool contains = repo.Customers.Contains(customer);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_ReturnsFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer notContainingCustomer = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };

            repo.Customers.Add(customer);

            // act
            bool contains = repo.Customers.Contains(notContainingCustomer);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_RemovingItem_ReturnTrue()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            repo.Customers.Add(customer);

            // act
            bool removed = repo.Customers.Remove(customer);

            // assert
            Assert.That(removed, Is.True);
        }

        [Test]
        public void Remove_RemovingItem_ReturnsFalse()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };

            // act
            bool removed = repo.Customers.Remove(customer);

            // assert
            Assert.That(removed, Is.False);
        }

        [Test]
        public void Remove_RemovingItem_NotContaining()
        {
            // arrange
            Customer customer = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            repo.Customers.Add(customer);

            // act
            bool removed = repo.Customers.Remove(customer);

            // assert
            bool contianing = repo.Customers.Contains(customer);
            Assert.That(contianing, Is.False);
        }

        [Test]
        public void GetAll_BaseOperation_CorrectCount()
        {
            // arrange
            Customer customer1 = new Customer() { FirstName = "John", LastName = "Doe", PostalCode = "94105", City = "San Francisco", StreetName = "Market St", HouseNumber = "200", EmailAddress = "johndoe@example.com", WebsiteURL = "www.johndoe.com", Password = "pass123" };
            Customer customer2 = new Customer() { FirstName = "Jane", LastName = "Smith", PostalCode = "10001", City = "New York", StreetName = "5th Ave", HouseNumber = "100", EmailAddress = "janesmith@example.com", WebsiteURL = "www.janesmith.com", Password = "pass456" };
            Customer customer3 = new Customer() { FirstName = "James", LastName = "Johnson", PostalCode = "60601", City = "Chicago", StreetName = "Michigan Ave", HouseNumber = "150", EmailAddress = "jamesjohnson@example.com", WebsiteURL = "www.jamesjohnson.com", Password = "pass789" };

            repo.Customers.Add(customer1);
            repo.Customers.Add(customer2);
            repo.Customers.Add(customer3);

            int expectedCount = 3;

            // act
            ICollection<Customer> returnedArticles = repo.Customers.GetAll();

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
            ICollection<Customer> returnedArticles = repo.Customers.GetAll();

            // assert
            int count = returnedArticles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }
    }
}