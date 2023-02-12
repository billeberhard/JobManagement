using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Position
    {
        public Position(Article article, int amount, Order order)
        {
            Article = article;
            Amount = amount;
            Order = order;
        }
        internal Position(PositionEntity entity)
        {
            PositionId = entity.PositionId;
            Article = new Article(entity.Article);
            Amount = entity.Amount;
            Order = new Order(entity.Order);
        }
        
        internal int PositionId { get; set; }
        public virtual Article Article { get; set; }
        public int Amount { get; set; }
        public virtual Order Order { get; set; }

        internal PositionEntity ConvertToEntity()
        {
            return new PositionEntity()
            {
                Article = Article.ConvertToEntity(),
                Amount = Amount,
                Order = Order.ConvertToEntity()
            };
        }
        public override string? ToString()
        {
            return $"{Amount}: {Article}";
        }
        public override bool Equals(object? obj)
        {
            return obj is Position position &&
                   PositionId == position.PositionId;
        }
        public bool DataEquals(object? obj)
        {
            return obj is Position position &&
                   Article.DataEquals(position.Article) &&
                   Amount == position.Amount &&
                   Order.DataEquals(position.Order);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(PositionId, Article, Amount, Order);
        }
    }
}