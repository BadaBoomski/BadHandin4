using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartGridInfo.Interfaces;
using SmartGridInfo.Models;

namespace SmartGridInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartGridProsumersController : ControllerBase
    {
        private readonly ISmartGridProsumerRepo _repo;

        public SmartGridProsumersController(ISmartGridProsumerRepo repo)
        {
            _repo = repo;
        }

        // GET: api/SmartGridProsumers
        [HttpGet]
        public IEnumerable<SmartGridProsumer> GetSmartGridProsumers()
        {
            return _repo.GetAll();
            //return _context.SmartGridProsumers;
        }

        // GET: api/SmartGridProsumers/5
        [HttpGet("{id}")]
        public IActionResult GetSmartGridProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGridProsumer = _repo.GetByID(id);
            //var smartGridProsumer = await _context.SmartGridProsumers.FindAsync(id);

            if (smartGridProsumer == null)
            {
                return NotFound();
            }

            return Ok(smartGridProsumer);
        }

        // PUT: api/SmartGridProsumers/5
        [HttpPut("{id}")]
        public IActionResult PutSmartGridProsumer([FromRoute] int id, [FromBody] SmartGridProsumer smartGridProsumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartGridProsumer.SmartGridProsumerID)
            {
                return BadRequest();
            }

            _repo.UpdateSmartGridProsumer(smartGridProsumer);
            _repo.Save();

            //_context.Entry(smartGridProsumer).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SmartGridProsumerExists(id))
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

        // POST: api/SmartGridProsumers
        [HttpPost]
        public IActionResult PostSmartGridProsumer([FromBody] SmartGridProsumer smartGridProsumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.InsertSmartGridProsumer(smartGridProsumer);
            _repo.Save();

            //_context.SmartGridProsumers.Add(smartGridProsumer);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartGridProsumer", new { id = smartGridProsumer.SmartGridProsumerID }, smartGridProsumer);
        }

        // DELETE: api/SmartGridProsumers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSmartGridProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartGridProsumer = _repo.GetByID(id);
            //var smartGridProsumer = await _context.SmartGridProsumers.FindAsync(id);
            if (smartGridProsumer == null)
            {
                return NotFound();
            }

            _repo.RemoveSmartGridProsumer(id);
            _repo.Save();

            //_context.SmartGridProsumers.Remove(smartGridProsumer);
            //await _context.SaveChangesAsync();

            return Ok(smartGridProsumer);
        }

    }
}