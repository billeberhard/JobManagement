using DataLayer.Model;
using System.Diagnostics;

namespace DataLayer.TransferObjects
{
    public class ArticleGroup
    {
        public ArticleGroup(string name, ArticleGroup superiorArticleGroup)
        {
            Name = name;
            SuperiorArticleGroup = superiorArticleGroup;
        }
        public ArticleGroup(string name)
        {
            Name = name;
        }
        internal ArticleGroup(ArticleGroupEntity entity)
        {
            ArticleGroupId = entity.ArticleGroupId;
            Name = entity.Name;
            SuperiorArticleGroup = entity.SuperiorArticleGroup == null ? null : new ArticleGroup(entity.SuperiorArticleGroup);
        }

        internal int ArticleGroupId { get; set; }
        public string Name { get; set; }
        public ArticleGroup? SuperiorArticleGroup { get; set; }

        internal ArticleGroupEntity ConvertToEntity()
        {
            if (SuperiorArticleGroup == null)
                return new ArticleGroupEntity()
                {
                    Name = Name
                };

            return new ArticleGroupEntity()
            {
                Name = Name,
                SuperiorArticleGroup = SuperiorArticleGroup.ConvertToEntity()
            };
        }
        public override string? ToString()
        {
            if (SuperiorArticleGroup == null)
                return $"{Name}";

            return $"{Name}.{SuperiorArticleGroup}";
        }

        public override bool Equals(object? obj)
        {
            return obj is ArticleGroup group &&
                   ArticleGroupId == group.ArticleGroupId;
        }
        public bool DataEquals(object? obj)
        {
            return obj is ArticleGroup group &&
                   Name == group.Name &&
                   ((SuperiorArticleGroup == null && group.SuperiorArticleGroup == null) || 
                   (SuperiorArticleGroup != null && SuperiorArticleGroup.DataEquals(group.SuperiorArticleGroup)));
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ArticleGroupId, Name, SuperiorArticleGroup);
        }
    }
}