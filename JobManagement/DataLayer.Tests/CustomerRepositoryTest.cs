using Castle.Core.Resource;
using DataLayer.Repository;
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
            ICollection<Customer> customers = GetSampleCustomers();
            int expectedCount = customers.Count;

            // act
            foreach (Customer c in customers)
                repo.Customers.Add(c);

            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameDataTwice_OnlyOneAdded()
        {
            // arrange
            ICollection<Customer> customers = GetSampleCustomers();
            int expectedCount = customers.Count;

            // act
            foreach (Customer c in customers)
                repo.Customers.Add(c);

            foreach (Customer c in customers)
                repo.Customers.Add(c);

            int count = repo.Customers.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_Contains()
        {
            // arrange
            Location location = new Location("94105", "San Francisco");
            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

            repo.Customers.Add(customer);

            // act
            bool contains = repo.Customers.Contains(customer);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_NotContaining()
        {
            // arrange
            Location location1 = new Location("94105", "San Francisco");
            Location location2 = new Location("10001", "New York");
            Customer customer = new Customer("John", "Doe", location1, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            Customer notContainingCustomer = new Customer("John", "Doe", location2, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");


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
            Location location = new Location("10001", "New York");
            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
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
            Location location = new Location("10001", "New York");
            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");

            // act
            bool removed = repo.Customers.Remove(customer);

            // assert
            Assert.That(removed, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_NotContainingItem()
        {
            // arrange
            Location location = new Location("10001", "New York");
            Customer customer = new Customer("John", "Doe", location, "Market St", "200", "johndoe@example.com", "www.johndoe.com", "pass123");
            repo.Customers.Add(customer);

            // act
            repo.Customers.Remove(customer);
            bool contains = repo.Customers.Contains(customer);

            // assert
            Assert.That(contains, Is.False);
        }
    }
}