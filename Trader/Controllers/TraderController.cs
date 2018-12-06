using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderInfo.Models;
using TraderInfo.Repository;

namespace TraderInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TraderController : Controller
    {

        private ITraderRepository<Trader> tradeRepository;

        public TraderController(ITraderRepository<Trader> tradeRepository)
        {
            this.tradeRepository = tradeRepository;
        }

        // GET: api/Trader
        [HttpGet]
        public async Task<IQueryable<Trader>> GetALL()
        {
            return await tradeRepository.GetAllItemsAsync();
        }

        // GET: api/Trader/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetItemByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Trader trade = await tradeRepository.GetItemAsync(id.ToString());

            if (trade == null)

            {
                return NotFound();
            }

            return Ok(trade);


        }

        // POST: api/Trader
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Trader trader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await tradeRepository.CreateItemAsync(trader);

            return Ok(trader);
        }

        // PUT: api/Trader/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Trader trader)
        {
            var t1 = tradeRepository.GetItemsAsync(t => t.id == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (t1 == null)
            {
                return NotFound();
            }

            await tradeRepository.UpdateItemAsync(id.ToString(), trader);

            return Ok(t1);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Trader trader = await tradeRepository.GetItemAsync(id);

            if(trader == null)
            {
                return NotFound();
            }

            await tradeRepository.DeleteItemAsync(id);
            return Ok();
        }
    }
}
