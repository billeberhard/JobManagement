using DataLayer.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataLayer.TransferObjects
{
    public class ArticleGroup
    {
        public ArticleGroup()
        { }
        internal ArticleGroup(ArticleGroupEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            SuperiorArticleGroup = entity.SuperiorArticleGroup == null ? null : new ArticleGroup(entity.SuperiorArticleGroup);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ArticleGroup? SuperiorArticleGroup { get; set; }

        internal ArticleGroupEntity ToEntity()
        {
            var entity = new ArticleGroupEntity()
            {
                Name = Name,
                SuperiorArticleGroup = SuperiorArticleGroup?.ToEntity()
            };

            if (Id != 0)
                entity.Id = Id;

            return entity;
        }
    }
}