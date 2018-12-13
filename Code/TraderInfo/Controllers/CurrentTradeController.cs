//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using TraderInfo.Interfaces;
//using TraderInfo.Models;
//using TraderInfo.Repository;

//namespace TraderInfo.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/[controller]")]
//    public class CurrentTradeController : Controller
//    {
//        private readonly IAzureDBRepository<CurrentTrade> _repo;

//        public CurrentTradeController(IAzureDBRepository<CurrentTrade> repo)
//        {
//            this._repo = repo;
//        }

//        // GET: api/CompletedTradesLog
//        [HttpGet]
//        public async Task<IQueryable<CurrentTrade>> GetAll()
//        {
//            return await _repo.GetAllTradesAsync();
//        }

//        // GET: api/CompletedTradesLog/5
//        [HttpGet("{id}", Name = "GetCurrentTrades")]
//        public async Task<IActionResult> GetItemByID([FromRoute] int id)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            CurrentTrade t = await _repo.GetTradeAsync(id.ToString());
//            if (t == null) return NotFound();
//            return Ok(t);
//        }

//        // POST: api/CompletedTradesLog
//        [HttpPost]
//        public async Task<IActionResult> PostItem([FromBody] CurrentTrade t)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            await _repo.CreateTradeAsync(t);
//            return Ok(t);
//        }

//        // PUT: api/CompletedTradesLog/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(string id, [FromBody] CurrentTrade t)
//        {
//            var t1 = _repo.GetTradesAsync(tr => tr.Id == id);
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            if (t1 == null) return NotFound();
//            await _repo.UpdateTradeAsync(id.ToString(), t);
//            return Ok(t1);
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete([FromRoute] int id)
//        {
//            if (!ModelState.IsValid) return BadRequest();
//            CurrentTrade t = await _repo.GetTradeAsync(id.ToString());
//            if (t == null) return NotFound();
//            await _repo.DeleteTradeAsync(id.ToString());
//            return Ok();
//        }
//    }
//}
