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
        private readonly ISmartGridRepo _smartgridRepo;

        public SmartGridsController(ISmartGridRepo smartGridRepo)
        {
            _smartgridRepo = smartGridRepo;
        }

        // GET: api/SmartGrids
        [HttpGet]
        public IEnumerable<SmartGrid> GetSmartGrids()
        {
            return _smartgridRepo.GetAll();
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

            if (smartGrid == null)
            {
                return NotFound();
            }

            _smartgridRepo.RemoveSmartGrid(id);
            _smartgridRepo.Save();

            return Ok(smartGrid);
        }
    }
}