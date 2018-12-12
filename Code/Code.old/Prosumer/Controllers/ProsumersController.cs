using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prosumer.Interface;
using Prosumer.Models;

namespace Prosumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsumersController : ControllerBase
    {
        private readonly ProsumerDBContext _context;
        private readonly IProsumerRepo _prosumerRepo;

        public ProsumersController(IProsumerRepo repo)
        {
            _prosumerRepo = repo;
        }

        // GET: api/Prosumers
        [HttpGet]
        public IEnumerable<Models.Prosumer> GetProsumers()
        {
            return _prosumerRepo.GetAll();
            //return _context.Prosumers;
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public IActionResult GetProsumer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _prosumerRepo.GetByID(id);
            //var prosumer = await _context.Prosumers.FindAsync(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [HttpPut("{id}")]
        public IActionResult PutProsumer([FromRoute] int id, [FromBody] Models.Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.ProsumerID)
            {
                return BadRequest();
            }

            _prosumerRepo.UpdateProsumer(prosumer);
            _prosumerRepo.Save();

            return NoContent();
        }

        //Async example
        // PUT: api/Prosumers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProsumer([FromRoute] int id, [FromBody] Prosumer prosumer)
        //{
        //    if (!ModelState.IsValid) { return BadRequest(ModelState); }
        //    if (id != prosumer.ProsumerID) { return BadRequest(); }
        //    _context.Entry(prosumer).State = EntityState.Modified;
        //    try { await _context.SaveChangesAsync(); }
        //    catch (DbUpdateConcurrencyException) { if (!ProsumerExists(id)) { return NotFound(); } else { throw; } }
        //    return NoContent();
        //}

        // POST: api/Prosumers
        [HttpPost]
        public IActionResult PostProsumer([FromBody] Models.Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _prosumerRepo.InsertProsumer(prosumer);
            _prosumerRepo.Save();
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

            var prosumer = _prosumerRepo.GetByID(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _prosumerRepo.RemoveProsumer(id);
            _prosumerRepo.Save();

            return Ok(prosumer);
        }
    }
}