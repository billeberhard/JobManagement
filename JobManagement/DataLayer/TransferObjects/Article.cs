using DataLayer.Model;

namespace DataLayer.TransferObjects
{
    public class Article
    {
        public Article()
        { }
        internal Article(ArticleEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Price = entity.Price;
            ArticleGroup = new ArticleGroup(entity.ArticleGroup);
        }

        internal int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ArticleGroup ArticleGroup { get; set; }

        internal ArticleEntity ToEntity()
        {
            var entity = new ArticleEntity()
            {
                Name = Name,
                Price = Price,
                ArticleGroup = ArticleGroup.ToEntity()
            };

            if (Id != 0)
                entity.Id = Id;

            return entity;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}