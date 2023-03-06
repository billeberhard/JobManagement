using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class ArticleRepository : IArticleRepository
    {
        public ArticleRepository(IArticleDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public bool Add(Article item)
        {
            return m_dataProvider.Add(item);
        }
        public void Clear()
        {
            m_dataProvider.ClearArticles();
        }
        public bool Contains(Article item)
        {
            return m_dataProvider.Contains(item);
        }
        public int Count()
        {
            return m_dataProvider.ArticleCount();
        }
        public ICollection<Article> GetAll()
        {
            return m_dataProvider.GetAllArticles();
        }
        public bool Remove(Article item)
        {
            return m_dataProvider.Remove(item);
        }

        private readonly IArticleDataProvider m_dataProvider;
    }
}
