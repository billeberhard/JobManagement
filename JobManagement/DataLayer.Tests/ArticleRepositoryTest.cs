using Castle.Core.Resource;
using DataLayer.Repository;
using DataLayer.TransferObjects;
using NUnit.Framework;

namespace DataLayerTests
{
    [TestFixture]
    public class ArticleRepositoryTest : RepositoryTests
    {
        [Test]
        public void Count_BaseOperation_ExpectedAmount()
        {
            // arrange
            ICollection<Article> articles = GetSampleArticles();
            AddAll(articles);

            int expectedCount = articles.Count();

            // act
            int count = repo.Articles.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetAll_BaseOperation_CorrectCount()
        {
            // arrange
            ICollection<Article> articles = GetSampleArticles();
            AddAll(articles);

            int expectedCount = articles.Count();

            // act
            ICollection<Article> returnedArticles = repo.Articles.GetAll();
            int count = returnedArticles.Count();

            // assert
            Assert.That(count, Is.EqualTo(expectedCount));
        }
    }
}