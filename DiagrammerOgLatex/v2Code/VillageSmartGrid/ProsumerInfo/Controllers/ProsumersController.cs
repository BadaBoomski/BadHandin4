using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Models;
using ProsumerInfo.Interface;

namespace ProsumerInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsumersController : ControllerBase
    {
        private readonly IProsumerRepo _repo;

        public ProsumersController(IProsumerRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Prosumers
        [HttpGet]
        public IEnumerable<Prosumer> GetProsumers()
        {
            return _repo.GetAll();
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public IActionResult GetProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _repo.GetByID(id);
            //var prosumer = await _context.Prosumers.FindAsync(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [HttpPut("{id}")]
        public IActionResult PutProsumer([FromRoute] int id, [FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.ProsumerID)
            {
                return BadRequest();
            }

            _repo.UpdateProsumer(prosumer);
            _repo.Save();

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProsumerExists(id))
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

        // POST: api/Prosumers
        [HttpPost]
        public IActionResult PostProsumer([FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.InsertProsumer(prosumer);
            _repo.Save();
            return CreatedAtAction("GetProsumer", new { id = prosumer.ProsumerID }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _repo.GetByID(id);
            //var prosumer = await _context.Prosumers.FindAsync(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _repo.RemoveProsumer(id);
            _repo.Save();

            //_context.Prosumers.Remove(prosumer);
            //await _context.SaveChangesAsync();

            return Ok(prosumer);
        }
    }
}