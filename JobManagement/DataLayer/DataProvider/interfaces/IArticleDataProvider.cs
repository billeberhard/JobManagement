using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IArticleDataProvider : IBaseDataProvider<Article>
    {
        int ArticleCount();
        void ClearArticles();
        ICollection<Article> GetAllArticles();
    }
}
