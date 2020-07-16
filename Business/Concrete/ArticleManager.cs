using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }
        public bool Add(Article article)
        {
            try
            {
                _articleDal.Add(article);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Article article)
        {
            try
            {
                _articleDal.Delete(article);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Article Get(int ArticleId)
        {
            try
            {
                return _articleDal.Get(x => x.Id == ArticleId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Article> GetList()
        {
            try
            {
                return _articleDal.GetList().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool Update(Article article)
        {
            try
            {
                _articleDal.Update(article);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
