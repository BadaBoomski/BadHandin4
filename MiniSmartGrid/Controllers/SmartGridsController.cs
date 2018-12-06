using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSmartGrid.Models;

namespace MiniSmartGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartGridsController : ControllerBase
    {
        private readonly SmartGridDBContext _context;

        public SmartGridsController(SmartGridDBContext context)
        {
            _context = context;
        }

        // GET: api/SmartGrids
        [HttpGet]
        public IEnumerable<SmartGrid> GetSmartGrids()
        {
            return _context.SmartGrids;
        }

        // GET: api/SmartGrids/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmartGrid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGrid = await _context.SmartGrids.FindAsync(id);

            if (smartGrid == null)
            {
                return NotFound();
            }

            return Ok(smartGrid);
        }

        // PUT: api/SmartGrids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartGrid([FromRoute] int id, [FromBody] SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartGrid.SmartGridID)
            {
                return BadRequest();
            }

            _context.Entry(smartGrid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartGridExists(id))
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

        // POST: api/SmartGrids
        [HttpPost]
        public async Task<IActionResult> PostSmartGrid([FromBody] SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmartGrids.Add(smartGrid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartGrid", new { id = smartGrid.SmartGridID }, smartGrid);
        }

        // DELETE: api/SmartGrids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartGrid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGrid = await _context.SmartGrids.FindAsync(id);
            if (smartGrid == null)
            {
                return NotFound();
            }

            _context.SmartGrids.Remove(smartGrid);
            await _context.SaveChangesAsync();

            return Ok(smartGrid);
        }

        private bool SmartGridExists(int id)
        {
            return _context.SmartGrids.Any(e => e.SmartGridID == id);
        }
    }
}