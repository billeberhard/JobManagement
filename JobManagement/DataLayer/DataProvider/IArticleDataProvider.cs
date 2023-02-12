using DataLayer.TransferObjects;

namespace DataLayer.DataProvider
{
    internal interface IArticleDataProvider : IBaseDataProvider<Article>
    {
        int ArticleCount();
        void ClearArticles();
        ICollection<Article> GetAllArticles();
    }
}
