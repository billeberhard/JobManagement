using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class LocationRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_NoElements()
        {
            // arrange
            ICollection<Location> locations = GetSampleLocations();
            foreach (Location l in locations)
                repo.Locations.Add(l);

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
            ICollection<Location> locations = GetSampleLocations();
            int expectedCount = locations.Count;

            // act
            foreach (Location l in locations)
                repo.Locations.Add(l);

            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameDataTwice_OnlyOneAdded()
        {
            // arrange
            ICollection<Location> locations = GetSampleLocations();
            int expectedCount = locations.Count;

            // act
            foreach (Location l in locations)
                repo.Locations.Add(l);

            foreach (Location l in locations)
                repo.Locations.Add(l);

            int count = repo.Locations.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingLocatoinOverCustomer_Added()
        {
            // arrange
            Location location = new Location("94105", "San Francisco");
            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

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
            Location location = new Location("94105", "San Francisco");
            repo.Locations.Add(location);

            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
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
            Location location = new Location("10001", "New York");

            repo.Locations.Add(location);

            // act
            bool contains = repo.Locations.Contains(location);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_NotContaining()
        {
            // arrange
            Location location = new Location("10001", "New York");

            // act
            bool contains = repo.Locations.Contains(location);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_ItemNotContained()
        {
            // arrange
            Location locatoin = new Location("10001", "New York");
            repo.Locations.Add(locatoin);

            // act
            repo.Locations.Remove(locatoin);
            bool contains = repo.Locations.Contains(locatoin);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_ReturnsTrue()
        {
            // arrange
            Location location = new Location("10001", "New York");
            repo.Locations.Add(location);

            // act
            bool removed = repo.Locations.Remove(location);

            // assert
            Assert.That(removed, Is.True);
        }

        [Test]
        public void Remove_RemoveNonExisting_ReturnsFalse()
        {
            // arrange
            Location location = new Location("10001", "New York");

            // act
            bool removed = repo.Locations.Remove(location);

            // assert
            Assert.That(removed, Is.False);
        }
    }
}