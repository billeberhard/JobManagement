using DataLayer.Model;
using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IArticleGroupDataProvider : IBaseDataProvider<ArticleGroup>
    {
        int ArticleGroupCount();
        void ClearArticleGroups();
        ICollection<ArticleGroup> GetAllArticleGroups();
        ICollection<ArticleGroup> GetAllRootArticleGroups();
        ICollection<ArticleGroup> SearchArticleGroups(string searchingContext);
        ICollection<HierarcicalArticleGroup> GetHirarcicalArticleGroups();
    }
}
