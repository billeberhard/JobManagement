﻿using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IArticleGroupDataProvider : IBaseDataProvider<ArticleGroup>
    {
        int ArticleGroupCount();
        void ClearArticleGroups();
        List<ArticleGroup> GetAllArticleGroups();
    }
}
