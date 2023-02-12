using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Article
    {
        public Article(string name, decimal price, ArticleGroup articleGroup)
        {
            Name = name;
            Price = price;
            ArticleGroup = articleGroup;
        }
        internal Article(ArticleEntity entity)
        {
            ArticleId = entity.ArticleId;
            Name = entity.Name;
            Price = entity.Price;
            ArticleGroup = new ArticleGroup(entity.ArticleGroup);
        }

        internal int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ArticleGroup ArticleGroup { get; set; }

        internal ArticleEntity ConvertToEntity()
        {
            return new ArticleEntity()
            {

                Name = Name,
                Price = Price,
                ArticleGroup = ArticleGroup.ConvertToEntity()
            };
        }
        public override string? ToString()
        {
            return Name;
        }
        public override bool Equals(object? obj)
        {
            return obj is Article article &&
                   ArticleId == article.ArticleId;
        }
        public bool DataEquals(object? obj)
        {
            return obj is Article article &&
                   Name == article.Name &&
                   Price == article.Price &&
                   ArticleGroup.DataEquals(article.ArticleGroup);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ArticleId, Name, Price, ArticleGroup);
        }
    }
}