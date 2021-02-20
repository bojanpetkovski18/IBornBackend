using DBL.Services;
using DBL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FastFitFierceWeb.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryLogic logic;

        public CategoriesController(CategoryLogic _logic)
            => logic = _logic;

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> AllCategories()
        {
            var categories = await logic.GetAllCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetCategory(int? id)
        {
            var category = await logic.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateCategory(int? id, CategoryViewModel category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            logic.UpdateCategory(category);
               
            try
            {
                await Task.Run(() => logic.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else throw;
            }

            return NoContent();
        }

        // POST: api/Categories
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateCategory(CategoryViewModel category)
        {
            logic.AddCategory(category);
            await Task.Run(() => logic.SaveChanges());

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            var category = await logic.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            logic.DeleteCategory(category);
            await Task.Run(() => logic.SaveChanges());

            return NoContent();
        }

        private bool CategoryExists(int? id)
        {
            return logic.DoesExist(id);
        }
    }
}
