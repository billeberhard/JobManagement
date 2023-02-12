using Castle.Core.Resource;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class ArticleGroupRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_NoElements()
        {
            // arrange
            ICollection<ArticleGroup> articleGroups = GetSampleArticleGroups();
            AddAll(articleGroups);
            int expectedCount = 0;

            // act
            repo.ArticleGroups.Clear();
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Count_AddingItems_ExpectedAmount()
        {
            ICollection<ArticleGroup> articleGroups = GetSampleArticleGroups();
            int expectedCount = articleGroups.Count;

            // act
            AddAll(articleGroups);
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameDataTwice_OnlyOneAdded()
        {
            ICollection<ArticleGroup> articleGroups = GetSampleArticleGroups();
            AddAll(articleGroups);
            int expectedCount = articleGroups.Count;

            // act
            AddAll(articleGroups);
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingSameDataTwiceOverOther_OnlyOneAdded()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            
            repo.ArticleGroups.Add(vehicle);
            int expectedCount = 2;

            // act
            repo.ArticleGroups.Add(car);
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_AddingOverOther_OnlyOneAdded()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            int expectedCount = 3;

            // act
            repo.ArticleGroups.Add(bmw);
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_Contains()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(bmw);

            // act
            bool contains = repo.ArticleGroups.Contains(car);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_NotContaining()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(car);

            // act
            bool contains = repo.ArticleGroups.Contains(bmw);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_ItemNotContaining()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(bmw);

            // act
            repo.ArticleGroups.Remove(bmw);
            bool contains = repo.ArticleGroups.Contains(bmw);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Remove_RemovingItem_ReturnTrue()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(bmw);

            // act
            bool removed = repo.ArticleGroups.Remove(bmw);

            // assert
            Assert.That(removed, Is.True);
        }

        [Test]
        public void Remove_RemovingNoExistingItem_ReturnsFalse()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(car);

            // act
            bool removed = repo.ArticleGroups.Remove(bmw);

            // assert
            Assert.That(removed, Is.False);
        }

        [Test]
        public void Remove_RemovingWithSubordinateArticleGroup_ReturnsFalse()
        {
            // arrange
            var vehicle = new ArticleGroup("Vehilce");
            var car = new ArticleGroup("Car", vehicle);
            var bmw = new ArticleGroup("BMW", car);

            repo.ArticleGroups.Add(bmw);

            // act
            bool removed = repo.ArticleGroups.Remove(vehicle);

            // assert
            Assert.That(removed, Is.False);
        }
    }
}