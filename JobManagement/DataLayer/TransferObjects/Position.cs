using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Position : IConvertableToEntity<PositionEntity>
    {
        public Position(Article article, int amount, Order order)
        {
            Article = article;
            Amount = amount;
            Order = order;
        }
        internal Position(PositionEntity entity)
        {
            Article = new Article(entity.Article);
            Amount = entity.Amount;
            Order = new Order(entity.Order);
        }

        public virtual Article Article { get; set; }
        public int Amount { get; set; }
        public virtual Order Order { get; set; }

        public PositionEntity ConvertToEntity()
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
                   EqualityComparer<Article>.Default.Equals(Article, position.Article) &&
                   Amount == position.Amount &&
                   EqualityComparer<Order>.Default.Equals(Order, position.Order);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Article, Amount, Order);
        }
    }
}