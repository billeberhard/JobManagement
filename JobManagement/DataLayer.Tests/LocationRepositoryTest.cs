using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayer.Tests
{
    [TestFixture]
    public class LocationRepositoryTest
    {
        [Test]
        public void Clear_BaseOperation_NoElements()
        {
            // arrange
            DataRepository repo = new DataRepository();

            Location location1 = new Location("94105", "San Francisco");
            repo.Locations.Add(location1);

            const int expectedCount = 0;

            // act

            repo.Locations.Clear();
            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Count_Adding3_ExpectedAmount()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("10001", "New York");
            Location location3 = new Location("60601", "Chicago");

            const int expectedCount = 3;

            // act

            repo.Locations.Add(location1);
            repo.Locations.Add(location2);
            repo.Locations.Add(location3);
            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }
        
        [Test]
        public void Add_AddingSameDataTwice_OnlyOneAdded()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("94105", "San Francisco");

            const int expectedCount = 1;

            // act

            repo.Locations.Add(location1);
            repo.Locations.Add(location2);

            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameObjectTwice_OnlyOneAdded()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();

            Location location1 = new Location("94105", "San Francisco");

            const int expectedCount = 1;

            // act

            repo.Locations.Add(location1);
            repo.Locations.Add(location1);

            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingLocatoinOverCustomer_Added()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Customers.Clear();
            repo.Locations.Clear();

            Location location = new Location("94105", "San Francisco");
            Customer customer = new Customer(1, "John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

            // act
            repo.Customers.Add(customer);
            bool contains = repo.Locations.Contains(location);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Add_AddingExistingLocationOverCustomer_NotAddedTwice()
        {
            // arrange
            DataRepository repo = new DataRepository();
            repo.Locations.Clear();
            repo.Customers.Clear();

            Location location = new Location("94105", "San Francisco");
            repo.Locations.Add(location);

            Customer customer = new Customer(1, "John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

            const int expectedCount = 1;

            // act
            repo.Customers.Add(customer);
            int count = repo.Locations.Count();

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
    }
}