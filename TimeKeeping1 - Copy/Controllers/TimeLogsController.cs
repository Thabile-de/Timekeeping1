using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeKeeping1.Data;
using TimeKeeping1.Model;

namespace TimeKeeping1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogsController : ControllerBase
    {
        private readonly TimeKeeping1Context _context;

        public TimeLogsController(TimeKeeping1Context context)
        {
            _context = context;
        }

        // GET: api/TimeLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeLog>>> GetTimeLog()
        {
            return await _context.TimeLog.ToListAsync();
        }

        // GET: api/TimeLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeLog>> GetTimeLog(int id)
        {
            var timeLog = await _context.TimeLog.FindAsync(id);

            if (timeLog == null)
            {
                return NotFound();
            }

            return timeLog;
        }

        // PUT: api/TimeLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeLog(int id, TimeLog timeLog)
        {
            if (id != timeLog.TimeLogId)
            {
                return BadRequest();
            }

            _context.Entry(timeLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TimeLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeLog>> PostTimeLog(TimeLog timeLog)
        {
            _context.TimeLog.Add(timeLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeLog", new { id = timeLog.TimeLogId }, timeLog);
        }

        // DELETE: api/TimeLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeLog(int id)
        {
            var timeLog = await _context.TimeLog.FindAsync(id);
            if (timeLog == null)
            {
                return NotFound();
            }

            _context.TimeLog.Remove(timeLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeLogExists(int id)
        {
            return _context.TimeLog.Any(e => e.TimeLogId == id);
        }
    }
}
