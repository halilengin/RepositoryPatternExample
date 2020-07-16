using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IArticleService
    {
        List<Article> GetList();
        bool Add(Article article);
        bool Delete(Article article);
        bool Update(Article article);
        Article Get(int ArticleId);
    }
}
