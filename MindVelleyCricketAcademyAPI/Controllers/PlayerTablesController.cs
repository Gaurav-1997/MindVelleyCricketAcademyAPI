using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindVelleyCricketAcademyAPI.Models;

namespace MindVelleyCricketAcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerTablesController : ControllerBase
    {
        private readonly CricketAcademyDBContext _context;

        public PlayerTablesController(CricketAcademyDBContext context)
        {
            _context = context;
        }

        // GET: api/PlayerTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerTable>>> GetPlayerTables()
        {
            return await _context.PlayerTables.ToListAsync();
        }

        // GET: api/PlayerTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerTable>> GetPlayerTable(int id)
        {
            var playerTable = await _context.PlayerTables.FindAsync(id);

            if (playerTable == null)
            {
                return NotFound();
            }

            return playerTable;
        }

        // PUT: api/PlayerTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerTable(int id, PlayerTable playerTable)
        {
            if (id != playerTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerTableExists(id))
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

        // POST: api/PlayerTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlayerTable>> PostPlayerTable(PlayerTable playerTable)
        {
            _context.PlayerTables.Add(playerTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerTable", new { id = playerTable.Id }, playerTable);
        }

        // DELETE: api/PlayerTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerTable>> DeletePlayerTable(int id)
        {
            var playerTable = await _context.PlayerTables.FindAsync(id);
            if (playerTable == null)
            {
                return NotFound();
            }

            _context.PlayerTables.Remove(playerTable);
            await _context.SaveChangesAsync();

            return playerTable;
        }

        private bool PlayerTableExists(int id)
        {
            return _context.PlayerTables.Any(e => e.Id == id);
        }
    }
}
