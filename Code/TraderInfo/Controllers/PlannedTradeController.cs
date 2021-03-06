﻿//using System;
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
//    public class PlannedTradeController : Controller
//    {
//        private readonly IAzureDBRepository<PlannedTrade> _repo;

//        public PlannedTradeController(IAzureDBRepository<PlannedTrade> repo)
//        {
//            this._repo = repo;
//        }

//        // GET: api/CompletedTradesLog
//        [HttpGet]
//        public async Task<IQueryable<PlannedTrade>> GetAll()
//        {
//            return await _repo.GetAllTradesAsync();
//        }

//        // GET: api/CompletedTradesLog/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetItemByID([FromRoute] string id)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            var t = await _repo.GetTradeAsync(id);
//            if (t == null) return NotFound();
//            return Ok(t);
//        }

//        // POST: api/CompletedTradesLog
//        [HttpPost]
//        public async Task<IActionResult> PostItem([FromBody] PlannedTrade t)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            await _repo.CreateTradeAsync(t);
//            return Ok(t);
//        }

//        // PUT: api/CompletedTradesLog/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put(string id, [FromBody] PlannedTrade t)
//        {
//            var t1 = _repo.GetTradesAsync(ti => ti.Id == id);
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            if (t == null) return NotFound();
//            await _repo.UpdateTradeAsync(id.ToString(), t);
//            return Ok(t1);
//        }

//        // DELETE: api/ApiWithActions/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete([FromRoute] string id)
//        {
//            if (!ModelState.IsValid) return BadRequest();
//            var t = await _repo.GetTradeAsync(id);
//            if (t == null) return NotFound();
//            await _repo.DeleteTradeAsync(id);
//            return Ok();
//        }
//    }
//}
