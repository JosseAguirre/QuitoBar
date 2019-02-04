using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBares1.Data;

namespace WebApiBares1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarsController : ControllerBase
    {
        private readonly BarContext _context;

        public BarsController(BarContext context)
        {
            _context = context;
        }

        // GET: api/Bars
        [HttpGet]
        public IEnumerable<Bar> GetQuitoBares()
        {
            return _context.QuitoBares;
        }

        // GET: api/Bars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bar = await _context.QuitoBares.FindAsync(id);

            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }

        // PUT: api/Bars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBar([FromRoute] int id, [FromBody] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bar.id)
            {
                return BadRequest();
            }

            _context.Entry(bar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bars
        [HttpPost]
        public async Task<IActionResult> PostBar([FromBody] Bar bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuitoBares.Add(bar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBar", new { id = bar.id }, bar);
        }

        // DELETE: api/Bars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bar = await _context.QuitoBares.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }

            _context.QuitoBares.Remove(bar);
            await _context.SaveChangesAsync();

            return Ok(bar);
        }

        private bool BarExists(int id)
        {
            return _context.QuitoBares.Any(e => e.id == id);
        }
    }
}