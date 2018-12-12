using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsumerInfo.Interface;
using ProsumerInfo.Models;

namespace ProsumerInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsumerSmartMeterRecordsLogsController : ControllerBase
    {
        private readonly IProsumerSmartMeterRecordsLogRepo _repo;

        public ProsumerSmartMeterRecordsLogsController(IProsumerSmartMeterRecordsLogRepo repo)
        {
            _repo = repo;
        }

        // GET: api/ProsumerSmartMeterRecordsLogs
        [HttpGet]
        public IEnumerable<ProsumerSmartMeterRecordsLog> GetProsumerSmartMeterRecordsLogs()
        {
            return _repo.GetAll();
        }

        // GET: api/ProsumerSmartMeterRecordsLogs/5
        [HttpGet("{id}")]
        public IActionResult GetProsumerSmartMeterRecordsLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumerSmartMeterRecordsLog = _repo.GetByID(id);
            //var prosumerSmartMeterRecordsLog = await _context.ProsumerSmartMeterRecordsLogs.FindAsync(id);

            if (prosumerSmartMeterRecordsLog == null)
            {
                return NotFound();
            }

            return Ok(prosumerSmartMeterRecordsLog);
        }

        // PUT: api/ProsumerSmartMeterRecordsLogs/5
        [HttpPut("{id}")]
        public IActionResult PutProsumerSmartMeterRecordsLog([FromRoute] int id, [FromBody] ProsumerSmartMeterRecordsLog prosumerSmartMeterRecordsLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumerSmartMeterRecordsLog.ProsumerSmartMeterRecordsID)
            {
                return BadRequest();
            }

            //_context.Entry(prosumerSmartMeterRecordsLog).State = EntityState.Modified;

            _repo.UpdateProsumerSmartMeterRecordsLog(prosumerSmartMeterRecordsLog);
            _repo.Save();
            return NoContent();
        }

        // POST: api/ProsumerSmartMeterRecordsLogs
        [HttpPost]
        public IActionResult PostProsumerSmartMeterRecordsLog([FromBody] ProsumerSmartMeterRecordsLog prosumerSmartMeterRecordsLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.InsertProsumerSmartMeterRecordsLog(prosumerSmartMeterRecordsLog);
            _repo.Save();

            return CreatedAtAction("GetProsumerSmartMeterRecordsLog", new { id = prosumerSmartMeterRecordsLog.ProsumerSmartMeterRecordsID }, prosumerSmartMeterRecordsLog);
        }

        // DELETE: api/ProsumerSmartMeterRecordsLogs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProsumerSmartMeterRecordsLog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumerSmartMeterRecordsLog = _repo.GetByID(id);
            //var prosumerSmartMeterRecordsLog = await _context.ProsumerSmartMeterRecordsLogs.FindAsync(id);
            if (prosumerSmartMeterRecordsLog == null)
            {
                return NotFound();
            }

            _repo.RemoveProsumerSmartMeterRecordsLog(id);
            _repo.Save();

            return Ok(prosumerSmartMeterRecordsLog);
        }

    }
}