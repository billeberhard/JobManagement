using DataLayer.Model;
using DataLayer.TransferObjects;

namespace DataLayer.Repository
{
    public interface IArticleGroupRepository : IGenericRepository<ArticleGroup>
    {
        ICollection<HierarcicalArticleGroup> GetHirarcicalArticleGroups();
        ICollection<ArticleGroup> GetAllAtRoot();
    }
}