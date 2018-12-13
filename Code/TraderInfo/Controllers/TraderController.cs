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
    public class TraderController : Controller
    {
        private IAzureDBRepository<Trader> _repo;

        public TraderController(IAzureDBRepository<Trader> _repo)
        {
            this._repo = _repo;
        }

        // GET: api/CompletedTradesLog
        [HttpGet]
        public async Task<IQueryable<Trader>> GetAll()
        {
            return await _repo.GetAllTradesAsync();
        }

        // GET: api/CompletedTradesLog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByID([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Trader t = await _repo.GetTradeAsync(id.ToString());
            if (t == null) return NotFound();
            return Ok(t);
        }

        // POST: api/CompletedTradesLog
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Trader t)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _repo.CreateTradeAsync(t);
            return Ok(t);
        }

        // PUT: api/CompletedTradesLog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Trader t)
        {
            var t1 = _repo.GetTradesAsync(tr => tr.Id == id);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (t1 == null) return NotFound();
            await _repo.UpdateTradeAsync(id.ToString(), t);
            return Ok(t1);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest();
            Trader t = await _repo.GetTradeAsync(id);
            if (t == null) return NotFound();
            await _repo.DeleteTradeAsync(id.ToString());
            return Ok();
        }
    }
}
