using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGridInfo.Models;
using SmartGridInfo.Interfaces;
using SmartGridInfo.Repo;

namespace SmartGridInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartGridsController : ControllerBase
    {
        
        private readonly ISmartGridRepo _repo;

        public SmartGridsController(ISmartGridRepo repo)
        {
            _repo = repo;
        }

        // GET: api/SmartGrids
        [HttpGet]
        public IEnumerable<SmartGrid> GetSmartGrids()
        {
            return _repo.GetAll();
            //return _context.SmartGrids;
        }

        // GET: api/SmartGrids/5
        [HttpGet("{id}")]
        public IActionResult GetSmartGrid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGrid = _repo.GetByID(id);
            //var smartGrid = await _context.SmartGrids.FindAsync(id);

            if (smartGrid == null)
            {
                return NotFound();
            }

            return Ok(smartGrid);
        }

        // PUT: api/SmartGrids/5
        [HttpPut("{id}")]
        public IActionResult PutSmartGrid([FromRoute] int id, [FromBody] SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartGrid.SmartGridID)
            {
                return BadRequest();
            }
            _repo.UpdateSmartGrid(smartGrid);
            _repo.Save();

            //_context.Entry(smartGrid).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SmartGridExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/SmartGrids
        [HttpPost]
        public IActionResult PostSmartGrid([FromBody] SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.InsertSmartGrid(smartGrid);
            _repo.Save();

            //_context.SmartGrids.Add(smartGrid);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartGrid", new { id = smartGrid.SmartGridID }, smartGrid);
        }

        // DELETE: api/SmartGrids/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSmartGrid([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGrid = _repo.GetByID(id);
            //var smartGrid = await _context.SmartGrids.FindAsync(id);
            if (smartGrid == null)
            {
                return NotFound();
            }

            _repo.RemoveSmartGrid(id);
            _repo.Save();

            //_context.SmartGrids.Remove(smartGrid);
            //await _context.SaveChangesAsync();

            return Ok(smartGrid);
        }
    }
}