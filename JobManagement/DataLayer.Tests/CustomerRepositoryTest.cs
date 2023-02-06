using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayer.Tests
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        DataRepository repo;
        [SetUp]
        public void SetUp()
        {
            repo = new DataRepository();
        }

        [Test]
        public void Clear_BaseOperation_NoElements()
        {
            // arrange
            RemoveAllDataFromRepo();
            AddSampleCustomers();

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
            RemoveAllDataFromRepo();

            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            Customer customer1 = new Customer(1, "John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            Customer customer2 = new Customer(2, "Jane", "Smith", location2, "5th Ave", "100", "janesmith@example.com", "www.janesmith.com", "pass456");
            Customer customer3 = new Customer(3, "James", "Johnson", location3, "Michigan Ave", "150", "jamesjohnson@example.com", "www.jamesjohnson.com", "pass789");

            const int expectedCount = 3;

            // act
            repo.Customers.Add(customer1);
            repo.Customers.Add(customer2);
            repo.Customers.Add(customer3);

            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameDataTwice_OnlyOneAdded()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();
            repo.Customers.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("94105", "San Francisco");
            
            Customer customer1 = new Customer(1, "John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            Customer customer2 = new Customer(1, "John", "Doe", location2, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

            const int expectedCount = 1;

            // act
            repo.Customers.Add(customer1);
            repo.Customers.Add(customer2);

            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameObjectTwice_OnlyOneAdded()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();
            repo.Customers.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Customer customer1 = new Customer(1, "John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            
            const int expectedCount = 1;

            // act
            repo.Customers.Add(customer1);
            repo.Customers.Add(customer1);

            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_Contains()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location containedLocation = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            repo.Locations.Add(location1);
            repo.Locations.Add(containedLocation);
            repo.Locations.Add(location3);

            // act
            bool contains = repo.Locations.Contains(containedLocation);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_NotContaining()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location notContainingLocation = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            repo.Locations.Add(location1);
            repo.Locations.Add(location3);

            // act

            bool contains = repo.Locations.Contains(notContainingLocation);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_RemovingItem_ItemRemoved()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location removedLocatoin = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            repo.Locations.Add(location1);
            repo.Locations.Add(removedLocatoin);
            repo.Locations.Add(location3);

            // act
            repo.Locations.Remove(removedLocatoin);
            bool contains = repo.Locations.Contains(removedLocatoin);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_RemovingItem_ReturnsTrue()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location removedLocatoin = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            repo.Locations.Add(location1);
            repo.Locations.Add(removedLocatoin);
            repo.Locations.Add(location3);

            // act
            bool removed = repo.Locations.Remove(removedLocatoin);

            // assert
            Assert.That(removed, Is.True);
        }

        [Test]
        public void Remove_RemoveNonExisting_ReturnsFalse()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location toRemoveLocation = new Location("10001", "New York");

            // act
            bool removed = repo.Locations.Remove(toRemoveLocation);

            // assert
            Assert.That(removed, Is.False);
        }


        private void RemoveAllDataFromRepo()
        {
            repo.Locations.Clear();
            repo.Customers.Clear();
            repo.Articles.Clear();
            repo.ArticleGroups.Clear();
            repo.Orders.Clear();
            repo.Positions.Clear();
        }

        private ICollection<Customer> AddSampleCustomers()
        {
            ICollection<Customer> customers = new List<Customer>()
            {
                new Customer(1, "John", "Doe", new Location("94105", "San Francisco"), "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123"),
            new Customer(2, "Jane", "Smith", new Location("10001", "New York"), "5th Ave", "100", "janesmith@example.com", "www.janesmith.com", "pass456")
            };

            foreach (Customer c in customers)
            {
                repo.Customers.Add(c);
            }
            return customers;            
        }
    }
}