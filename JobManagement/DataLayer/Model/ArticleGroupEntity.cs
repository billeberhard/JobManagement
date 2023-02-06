namespace DataLayer.Model
{
    public class ArticleGroupEntity
    {
        public int ArticleGroupId { get; set; }
        public string Name { get; set; }
        public int SuperiorArticleGroupId { get; set; }
        public virtual ArticleGroupEntity SuperiorArticleGroup { get; set; }

        public virtual ICollection<ArticleGroupEntity> SubordinateArticleGroups { get; set; }
        public virtual ICollection<ArticleEntity> Articles { get; set; }
    }
}