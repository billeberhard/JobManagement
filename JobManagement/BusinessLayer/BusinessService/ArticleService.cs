using DataLayer.Repository;
using DataLayer.TransferObjects;

namespace BusinessLayer.BusinessService
{
    public class ArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }
        //public Article CreateArticle(Article article)
        //{

        //}

        public ICollection<Article> GetAllArticles()
        {
            return _repository.GetAll();
        }

        public Article GetArticleById(int id)
        {
            var articles = _repository.GetAll();
            return articles.FirstOrDefault(article => 12/*id input */ == id);
        }

        //public Article CreateArticle(Article article) 
        //{

        //}

        //public Article DeleteArticleById(int id) 
        //{ 
        
        //}
    }
}
