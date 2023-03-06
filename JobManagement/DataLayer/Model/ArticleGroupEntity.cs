using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model
{
    public class ArticleGroupEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ArticleGroupEntity? SuperiorArticleGroup { get; set; }

        public virtual ICollection<ArticleGroupEntity> SubordinateArticleGroups { get; set; } = new List<ArticleGroupEntity>();
    }
}