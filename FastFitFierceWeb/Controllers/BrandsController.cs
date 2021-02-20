using DBL.Services;
using DBL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FastFitFierceWeb.Controllers
{
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly BrandLogic logic;

        public BrandsController(BrandLogic _logic)
            => logic = _logic;

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> AllBrands()
        {
            var brands = await logic.GetAllBrands();
            return Ok(brands);
        }

        // GET: api/Brands/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetBrand(int? id)
        {
            var brand = await logic.GetBrandById(id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateBrand(int? id, BrandViewModel brand)
        {
            if (id != brand.BrandId)
            {
                return BadRequest();
            }

            logic.UpdateBrand(brand);

            try
            {
                await Task.Run(() => logic.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else throw;
            }

            return NoContent();
        }

        // POST: api/Brands
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateBrand(BrandViewModel brand)
        {
            logic.AddBrand(brand);
            await Task.Run(() => logic.SaveChanges());

            return CreatedAtAction("GetBrand", new { id = brand.BrandId}, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteBrand(int? id)
        {
            var brand = await logic.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }

            logic.DeleteBrand(brand);
            await Task.Run(() => logic.SaveChanges());

            return NoContent();
        }

        private bool BrandExists(int? id)
        {
            return logic.DoesExist(id);
        }
    }
}
