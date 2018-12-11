using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSmartGrid.Interfaces;
using MiniSmartGrid.Models;

namespace MiniSmartGrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartGridsController : ControllerBase
    {
        private readonly SmartGridDBContext _context;
        private readonly ISmartGridRepo _smartgridRepo;

        public SmartGridsController(ISmartGridRepo smartGridRepo)
        {
            _smartgridRepo = smartGridRepo;
        }

        //public SmartGridsController(SmartGridDBContext Context)
        //{
        //    _context = Context;
        //}

        // GET: api/SmartGrids
        [HttpGet]
        public IEnumerable<SmartGrid> GetSmartGrids()
        {
            return _smartgridRepo.GetAll();
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


            var smartGrid = _smartgridRepo.GetByID(id);
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

            _smartgridRepo.UpdateSmartGrid(smartGrid);
            _smartgridRepo.Save();
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

            return Ok(smartGrid);
        }

        // POST: api/SmartGrids
        [HttpPost]
        public IActionResult PostSmartGrid([FromBody] SmartGrid smartGrid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _smartgridRepo.InsertSmartGrid(smartGrid);
            _smartgridRepo.Save();

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

            var smartGrid = _smartgridRepo.GetByID(id);

            //var smartGrid = await _context.SmartGrids.FindAsync(id);
            if (smartGrid == null)
            {
                return NotFound();
            }

            _smartgridRepo.RemoveSmartGrid(id);
            _smartgridRepo.Save();
            //_context.SmartGrids.Remove(smartGrid);
            //await _context.SaveChangesAsync();

            return Ok(smartGrid);
        }
    }
}