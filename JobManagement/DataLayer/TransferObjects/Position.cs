using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Position
    {
        public Position()
        { }
        internal Position(PositionEntity entity)
        {
            Id = entity.Id;
            Article = new Article(entity.Article);
            Amount = entity.Amount;
            Order = new Order(entity.Order);
        }

        public int Id { get; set; }
        public virtual Article Article { get; set; }
        public int Amount { get; set; }
        internal virtual Order Order { get; set; }

        internal PositionEntity ToEntity()
        {
            var entity = new PositionEntity()
            {
                Article = Article.ToEntity(),
                Amount = Amount,
                Order = Order?.ToEntity()
            };

            if (Id != 0)
                entity.Id = Id;

            return entity;
        }
    }
}