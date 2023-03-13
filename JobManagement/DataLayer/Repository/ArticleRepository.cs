using DataLayer.DataProvider.interfaces;
using DataLayer.TransferObjects;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer.Repository
{
    internal class ArticleRepository : IArticleRepository
    {
        public ArticleRepository(IArticleDataProvider dataProvider)
        {
            m_DataProvider = dataProvider;
        }

        public bool Add(Article item)
        {
            return m_DataProvider.Add(item);
        }
        public void Clear()
        {
            m_DataProvider.ClearArticles();
        }
        public bool Contains(Article item)
        {
            return m_DataProvider.Contains(item);
        }
        public int Count()
        {
            return m_DataProvider.ArticleCount();
        }
        public ICollection<Article> GetAll()
        {
            return m_DataProvider.GetAllArticles();
        }
        public bool Remove(Article item)
        {
            return m_DataProvider.Remove(item);
        }
        public bool Update(Article item)
        {
            return m_DataProvider.Update(item);
        }
        public ICollection<Article> Search(string searchingContext)
        {
            return m_DataProvider.SearchArticles(searchingContext);
        }

        private readonly IArticleDataProvider m_DataProvider;
    }
}
