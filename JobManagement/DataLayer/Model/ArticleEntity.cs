namespace DataLayer.Model
{
    public class ArticleEntity
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int ArticleGroupId { get; set; }
        public virtual ArticleGroupEntity ArticleGroup { get; set; }

        public virtual ICollection<PositionEntity> Positions { get; set; }
    }
}