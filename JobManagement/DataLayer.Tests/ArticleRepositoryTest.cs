using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class ArticleRepositoryTest : RepositoryTests
    {
        [Test]
        public void Clear_BaseOperation_ExpectedAmount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            int expectedCount = 0;

            repo.Articles.Add(article);

            // act
            repo.Articles.Clear();

            // assert
            int count = repo.Articles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_ExpectedAmount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };

            Article article1 = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Article article2 = new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle };
            Article article3 = new Article() { Name = "wrench", Price = 2.5M, ArticleGroup = vehicle };

            int expectedCount = 3;

            // act
            repo.Articles.Add(article1);
            repo.Articles.Add(article2);
            repo.Articles.Add(article3);

            // assert
            int count = repo.Articles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_BaseOperation_ReturnTrue()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            // act
            bool added = repo.Articles.Add(article);

            // assert
            Assert.That(added, Is.True);
        }

        [Test]
        public void Add_AddingSameTwice_ReturnFalse()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            repo.Articles.Add(article);

            // act
            bool added = repo.Articles.Add(article);

            // assert
            Assert.That(added, Is.False);
        }

        [Test]
        public void Add_AddingSameTwice_ExpectedCount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            repo.Articles.Add(article);
            int expectedCount = 1;

            // act
            repo.Articles.Add(article);

            // assert
            int count = repo.Articles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_BaseOperation_ReturnTrue()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            repo.Articles.Add(article);

            // act
            bool removed = repo.Articles.Remove(article);

            // assert
            Assert.That(removed, Is.True);
        }

        [Test]
        public void Remove_RemovingNotExisting_ReturnFalse()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            // act
            bool removed = repo.Articles.Remove(article);

            // assert
            Assert.That(removed, Is.False);
        }

        [Test]
        public void Remove_BaseOperation_ExpectedCount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            repo.Articles.Add(article);
            int expectedCount = 0;

            // act
            repo.Articles.Remove(article);

            // assert
            int count = repo.Articles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Contains_BaseOperation_ReturnTrue()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            repo.Articles.Add(article);

            // act
            bool contains = repo.Articles.Contains(article);

            // assert
            Assert.That(contains, Is.True);
        }

        [Test]
        public void Contains_BaseOperation_ReturnFalse()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };
            Article article = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };

            // act
            bool contains = repo.Articles.Contains(article);

            // assert
            Assert.That(contains, Is.False);
        }

        [Test]
        public void Count_BaseOperation_ExpectedAmount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };

            Article article1 = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Article article2 = new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle };
            Article article3 = new Article() { Name = "wrench", Price = 2.5M, ArticleGroup = vehicle };

            repo.Articles.Add(article1);
            repo.Articles.Add(article2);
            repo.Articles.Add(article3);

            int expectedCount = 3;

            // act
            int count = repo.Articles.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetAll_BaseOperation_CorrectCount()
        {
            // arrange
            ArticleGroup vehicle = new ArticleGroup() { Name = "Vehicle" };

            Article article1 = new Article() { Name = "screw", Price = 0.35M, ArticleGroup = vehicle };
            Article article2 = new Article() { Name = "nut", Price = 0.15M, ArticleGroup = vehicle };
            Article article3 = new Article() { Name = "wrench", Price = 2.5M, ArticleGroup = vehicle };

            repo.Articles.Add(article1);
            repo.Articles.Add(article2);
            repo.Articles.Add(article3);

            int expectedCount = 3;

            // act
            ICollection<Article> returnedArticles = repo.Articles.GetAll();
            int count = returnedArticles.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetAll_GetNoElements_CorrectCount()
        {
            // arrange
            int expectedCount = 0;

            // act
            ICollection<Article> returnedArticles = repo.Articles.GetAll();

            // assert
            int count = returnedArticles.Count();
            Assert.That(count, Is.EqualTo(expectedCount));
        }
    }
}