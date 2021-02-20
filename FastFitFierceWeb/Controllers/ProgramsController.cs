using DAL.DataContext;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFitFierceWeb.Controllers
{
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ProgramsController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> AllPrograms()
        {
            return Ok(await db.Programs.ToListAsync());
        }

        // GET: api/Programs/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> GetProgram(int? id)
        {
            var program = await db.Programs.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        // PUT: api/Programs/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateProgram(int? id, DAL.Entities.Program program)
        {
            if (id != program.ProgramId)
            {
                return BadRequest();
            }

            db.Entry(program).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
                {
                    return NotFound();
                }
                else throw;
            }

            return NoContent();
        }

        // POST: api/Programs
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateProgram(DAL.Entities.Program program)
        {
            db.Programs.Add(program);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetProgram", new { id = program.ProgramId }, program);
        }

        // DELETE: api/Programs/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteProgram(int? id)
        {
            var program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            db.Programs.Remove(program);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramExists(int? id)
        {
            return db.Programs.Any(e => e.ProgramId == id);
        }
    }
}
