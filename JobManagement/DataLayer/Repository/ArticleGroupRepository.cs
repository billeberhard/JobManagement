using DataLayer.DataProvider.interfaces;
using DataLayer.Model;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class ArticleGroupRepository : IArticleGroupRepository
    {
        public ArticleGroupRepository(IArticleGroupDataProvider dataProvider)
        {
            m_DataProvider = dataProvider;
        }

        public bool Add(ArticleGroup item)
        {
            return m_DataProvider.Add(item);
        }
        public void Clear()
        {
            m_DataProvider.ClearArticleGroups();
        }
        public bool Contains(ArticleGroup item)
        {
            return m_DataProvider.Contains(item);
        }
        public int Count()
        {
            return m_DataProvider.ArticleGroupCount();
        }
        public ICollection<ArticleGroup> GetAll()
        {
            return m_DataProvider.GetAllArticleGroups();
        }
        public bool Remove(ArticleGroup item)
        {
            return m_DataProvider.Remove(item);
        }
        public bool Update(ArticleGroup item)
        {
            return m_DataProvider.Update(item);
        }
        public ICollection<HierarcicalArticleGroup> GetHirarcicalArticleGroups()
        {
            return m_DataProvider.GetHirarcicalArticleGroups();
        }

        private readonly IArticleGroupDataProvider m_DataProvider;
    }
}