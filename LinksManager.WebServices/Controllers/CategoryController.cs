using System.Net;
using System.Web.Http;
using LinksManager.BusinessLogic.Abstract;
using LinksManager.Entities;

namespace LinksManager.WebServices.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpPost]
        public IHttpActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid || category == null)
            {
                return BadRequest(ModelState);
            }

            var result = _categoryService.AddCategory(category);
            if (!result)
            {
                return Conflict();
            }

            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult EditCategory(int id, Category category)
        {
            if (!ModelState.IsValid || category == null)
            {
                return BadRequest(ModelState);
            }
            var result = _categoryService.EditCategory(id, category);
            if (!result)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var result = _categoryService.DeleteCategory(id);
            if (!result)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(_categoryService.GetCategoryById(id));
        }
    }
}
