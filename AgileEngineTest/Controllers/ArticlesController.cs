using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AgileEngineTest.Controllers
{
    public class ArticlesController : Controller
    {
        #region Private properties
        private IRepository _repository;
        #endregion

        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }

        #region CRUD
        //I'll name every method assuming it's async even though  it's not implemented like that
        [HttpPost]
        public IActionResult PostAsync([FromBody] Article article)
        {
            try
            {
                if (string.IsNullOrEmpty(article.Title))
                {
                    return BadRequest();
                }
                var result = _repository.Create(article);
                article.Id = result;
                return Created($"/api/articles/{result}", article);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(Guid id)
        {
            try
            {
                var result = _repository.Delete(id);
                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(Guid id, [FromBody] Article newArticle)
        {
            try
            {
                if (string.IsNullOrEmpty(newArticle.Title))
                {
                    return BadRequest();
                }
                newArticle.Id = id;
                var result = _repository.Update(newArticle);
                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAsync(Guid id)
        {
            try
            {
                var result = _repository.Get(id);
                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
