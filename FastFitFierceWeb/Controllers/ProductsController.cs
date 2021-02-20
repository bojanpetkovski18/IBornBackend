using DBL.Logic;
using DBL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FastFitFierceWeb.Controllers
{
    
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductLogic logic;

        public ProductsController(ProductLogic _logic)
            => logic = _logic;

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> AllProducts()
        {
            var products = await logic.GetAllProducts();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            var product = await logic.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateProduct(int? id, ProductViewModel product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            logic.UpdateProduct(product);

            try
            {
                await Task.Run(() => logic.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else throw;
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            logic.AddProduct(product);
            await Task.Run(() => logic.SaveChanges());

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var product = await logic.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            logic.DeleteProduct(product);
            await Task.Run(() => logic.SaveChanges());

            return NoContent();
        }

        private bool ProductExists(int? id)
        {
            return logic.DoesExist(id);
        }

    }
}
