﻿using DataLayer.DataProvider;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    internal class ArticleGroupRepository : IArticleGroupRepository
    {
        public ArticleGroupRepository(IArticleGroupDataProvider dataProvider)
        {
            m_dataProvider = dataProvider;
        }

        public ArticleGroup Add(ArticleGroup item)
        {
            return m_dataProvider.Add(item);
        }
        public void Clear()
        {
            m_dataProvider.ClearArticleGroups();
        }
        public bool Contains(ArticleGroup item)
        {
            return m_dataProvider.Contains(item);
        }
        public int Count()
        {
            return m_dataProvider.ArticleGroupCount();
        }
        public ICollection<ArticleGroup> GetAll()
        {
            return m_dataProvider.GetAllArticleGroups();
        }
        public bool Remove(ArticleGroup item)
        {
            return m_dataProvider.Remove(item);
        }

        private readonly IArticleGroupDataProvider m_dataProvider;
    }
}