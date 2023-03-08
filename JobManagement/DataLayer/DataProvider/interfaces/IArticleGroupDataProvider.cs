using DataLayer.Model;
using DataLayer.TransferObjects;

namespace DataLayer.DataProvider.interfaces
{
    internal interface IArticleGroupDataProvider : IBaseDataProvider<ArticleGroup>
    {
        int ArticleGroupCount();
        void ClearArticleGroups();
        ICollection<ArticleGroup> GetAllArticleGroups();

        public ICollection<HierarcicalArticleGroup> GetHirarcicalArticleGroups();
    }
}
