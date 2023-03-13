using DataLayer.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.TransferObjects
{
    public class ArticleGroup
    {
        public ArticleGroup()
        { }
        internal ArticleGroup(ArticleGroupEntity entity)
        {
            ArticleGroupCreate(entity, null);
        }

        internal void ArticleGroupCreate(ArticleGroupEntity entity, ArticleGroup superiorArticleGroup)
        {
            Id = entity.Id;
            Name = entity.Name;
            SuperiorArticleGroup = superiorArticleGroup;

            var entities = entity.SubordinateArticleGroups;

            if (entities == null || entities.Count == 0)
                return;

            foreach (ArticleGroupEntity e in entities)
            {
                var childGroup = new ArticleGroup();
                childGroup.ArticleGroupCreate(e, this);
                SubordinateArticleGroups.Add(childGroup);
            }
        }

        public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        public ArticleGroup? SuperiorArticleGroup { get; set; }
        public ICollection<ArticleGroup> SubordinateArticleGroups { get; set; } = new List<ArticleGroup>();

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
        public override string ToString()
        {
            return Name;
        }
    }
}