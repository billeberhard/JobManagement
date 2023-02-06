using DataLayer.Model;
using System.Diagnostics;

namespace DataLayer.TransferObjects
{
    public class ArticleGroup : IConvertableToEntity<ArticleGroupEntity>
    {
        public ArticleGroup(string name, ArticleGroup superiorArticleGroup)
        {
            Name = name;
            SuperiorArticleGroup = superiorArticleGroup;
        }
        public ArticleGroup(ArticleGroupEntity entity)
        {
            Name = entity.Name;
            SuperiorArticleGroup = entity.SuperiorArticleGroup == null ? null : new ArticleGroup(entity.SuperiorArticleGroup);
        }

        public string Name { get; set; }
        public ArticleGroup? SuperiorArticleGroup { get; set; }

        public ArticleGroupEntity ConvertToEntity()
        {
            return new ArticleGroupEntity
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
                   Name == group.Name;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, SuperiorArticleGroup);
        }
    }
}