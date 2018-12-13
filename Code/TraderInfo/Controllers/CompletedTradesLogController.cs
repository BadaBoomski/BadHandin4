using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderInfo.Interfaces;
using TraderInfo.Models;
using TraderInfo.Repository;

namespace TraderInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CompletedTradesLogController : Controller
    {
        private readonly IAzureDBRepository<CompletedTradesLog> _repo;

        public CompletedTradesLogController(IAzureDBRepository<CompletedTradesLog> repo)
        {
            this._repo = repo;
        }

        // GET: api/CompletedTradesLog
        [HttpGet]
        public async Task<IQueryable<CompletedTradesLog>> GetAll()
        {
            return await _repo.GetAllTradesAsync();
        }

        // GET: api/CompletedTradesLog/5
        [HttpGet("{id}", Name = "GetCompletedTradesLogController")]
        public async Task<IActionResult> GetItemByID([FromRoute] int id)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);
            CompletedTradesLog t = new CompletedTradesLog();
            t = await _repo.GetTradeAsync(id.ToString());
            if (t == null) return NotFound();
            return Ok(t);
        }


        // POST: api/CompletedTradesLog
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] CompletedTradesLog t)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repo.CreateTradeAsync(t);
            return Ok(t);
        }

        // PUT: api/CompletedTradesLog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompletedTradesLog t2)
        {
            var t = _repo.GetTradesAsync(ti => ti.Id == id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (t == null) return NotFound();
            await _repo.UpdateTradeAsync(id.ToString(), t2);

            return Ok(t);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            CompletedTradesLog t = await _repo.GetTradeAsync(id.ToString());
            if (t == null) return NotFound();
            await _repo.DeleteTradeAsync(id.ToString());
            return Ok();
        }
    }
}
