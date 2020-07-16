using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _articleService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Ürün bulunamadı.");
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _articleService.Get(Id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Ürün bulunamadı.");
        }
        [HttpPost("add")]
        public IActionResult Add(Article article)
        {
            bool isAdded = _articleService.Add(article);
            if (isAdded)
            {
                return Ok("Ürün başarıyla eklendi.");
            }
            return BadRequest("İşlem başarısız.");
        }
        [HttpPost("delete")]
        public IActionResult Delete(Article article)
        {
            bool isDeleted = _articleService.Delete(article);
            if (isDeleted)
            {
                return Ok("Ürün başarıyla silindi.");
            }
            return BadRequest("İşlem başarısız.");
        }

        [HttpPost("update")]
        public IActionResult Update(Article article)
        {
            bool isUpdated = _articleService.Update(article);
            if (isUpdated)
            {
                return Ok("Ürün başarıyla güncellendi.");
            }
            return BadRequest("İşlem başarısız.");
        }

    }

}