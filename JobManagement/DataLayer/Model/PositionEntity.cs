namespace DataLayer.Model
{
    public class PositionEntity
    {
        public int PositionId { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleEntity Article { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public virtual OrderEntity Order { get; set; }
    }
}