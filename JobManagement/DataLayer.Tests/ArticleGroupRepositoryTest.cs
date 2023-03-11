using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class ArticleGroupRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_NoElementsContaining()
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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

            int expectedCount = 3;

            // act
            repo.ArticleGroups.Add(bmw);
            int count = repo.ArticleGroups.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_IdUpdated()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };

            int idBefore = vehicle.Id;

            // act
            repo.ArticleGroups.Add(vehicle);
            int idAfter = vehicle.Id;

            // assert
            Assert.That(idBefore, Is.EqualTo(0));
            Assert.That(idAfter, Is.Not.EqualTo(0));
        }

        [Test]
        public void Contains_BaseOperation_Contains()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

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
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup bmw = new ArticleGroup() { Name = "BMW", SuperiorArticleGroup = car };

            repo.ArticleGroups.Add(bmw);

            // act
            bool removed = repo.ArticleGroups.Remove(vehicle);

            // assert
            Assert.That(removed, Is.False);
        }

        [Test]
        public void GetAll_BaseOperation_CorrectCount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            ArticleGroup car = new ArticleGroup() { Name = "Car", SuperiorArticleGroup = vehicle };
            ArticleGroup plane = new ArticleGroup() { Name = "Plane", SuperiorArticleGroup = car };

            repo.ArticleGroups.Add(plane);

            int expectedCount = 3;

            // act
            ICollection<ArticleGroup> returnedArticles = repo.ArticleGroups.GetAll();

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
            ICollection<ArticleGroup> returnedArticles = repo.ArticleGroups.GetAll();

            // assert
            int count = returnedArticles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Update_BaseOperation_ReturnTrue()
        {
            // arrange
            ArticleGroup articleGroup = new ArticleGroup() { Name = "Vehicle" };

            repo.ArticleGroups.Add(articleGroup);

            // act
            articleGroup.Name = "ChangedName";
            bool updated = repo.ArticleGroups.Update(articleGroup);

            // assert
            Assert.That(updated, Is.True);
        }

        [Test]
        public void Update_BaseOperation_ValuesChanged()
        {
            // arrange
            ArticleGroup articleGroup = new ArticleGroup() { Name = "Vehicle" };
            repo.ArticleGroups.Add(articleGroup);

            string expectedName = "ChangedName";
            ArticleGroup expectedArticleGroup = new ArticleGroup() { Name = "expedctedArticle" };
            repo.ArticleGroups.Add(expectedArticleGroup);

            // act
            articleGroup.Name = expectedName;
            articleGroup.SuperiorArticleGroup = expectedArticleGroup;
            repo.ArticleGroups.Update(articleGroup);

            // assert
            var updatedArticleGroup = repo.ArticleGroups.GetAll().First();

            Assert.That(expectedArticleGroup.Id, Is.EqualTo(updatedArticleGroup.SuperiorArticleGroup.Id));
            Assert.AreEqual(expectedName, updatedArticleGroup.Name);
        }

        [Test]
        public void Update_NoChangesAreMade_ReturnFalse()
        {
            // arrange
            ArticleGroup articleGroup = new ArticleGroup() { Name = "Vehicle" };
            repo.ArticleGroups.Add(articleGroup);

            // act
            bool updated = repo.ArticleGroups.Update(articleGroup);

            // assert
            Assert.That(updated, Is.False);
        }
    }
}