using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Article : IConvertableToEntity<ArticleEntity>
    {
        public Article(int articleId, string name, decimal price, ArticleGroup articleGroup)
        {
            ArticleId = articleId;
            Name = name;
            Price = price;
            ArticleGroup = articleGroup;
        }
        public Article(ArticleEntity entity)
        {
            ArticleId = entity.ArticleId;
            Name = entity.Name;
            Price = entity.Price;
            ArticleGroup = new ArticleGroup(entity.ArticleGroup);
        }

        public int ArticleId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ArticleGroup ArticleGroup { get; set; }

        public ArticleEntity ConvertToEntity()
        {
            throw new NotImplementedException();
        }
        public override string? ToString()
        {
            return Name;
        }
        public override bool Equals(object? obj)
        {
            return obj is Article article &&
                   ArticleId == article.ArticleId &&
                   Name == article.Name &&
                   Price == article.Price;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ArticleId, Name, Price, ArticleGroup);
        }
    }
}