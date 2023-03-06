using DataLayer.Repository;
using DataLayer.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessService
{
    public class ArticleGroupService
    {
        private readonly IArticleRepository _repository;

    //    public ArticleGroupService(IArticleRepository repository)
    //    {
    //        _repository = repository;
    //    }

    public ICollection<Article> GetAllArticles()
    {
        return _repository.GetAll();
    }

    //    public Article GetArticleById(int id)
    //    {
    //        var articles = _repository.GetAll();
    //        return articles.FirstOrDefault(article => article.ArticleId == id);
    //    }
    }
}
