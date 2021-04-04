using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemApp.Models;

namespace ItemApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemsController : ControllerBase
    {
        private readonly MyContext _context;

        public SubItemsController(MyContext context)
        {
            _context = context;
        }

        // GET: api/SubItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubItem>>> GetSubItems()
        {
            return await _context.SubItems.ToListAsync();
        }

        // GET: api/SubItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubItem>> GetSubItem(int id)
        {
            var subItem = await _context.SubItems.FindAsync(id);

            if (subItem == null)
            {
                return NotFound();
            }

            return subItem;
        }

        // PUT: api/SubItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubItem(int id, SubItem subItem)
        {
            if (id != subItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(subItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubItemExists(id))
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

        // POST: api/SubItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubItem>> PostSubItem(SubItem subItem)
        {
            _context.SubItems.Add(subItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubItem), new { id = subItem.Id }, subItem);
        }

        // DELETE: api/SubItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubItem(int id)
        {
            var subItem = await _context.SubItems.FindAsync(id);
            if (subItem == null)
            {
                return NotFound();
            }

            _context.SubItems.Remove(subItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubItemExists(int id)
        {
            return _context.SubItems.Any(e => e.Id == id);
        }
    }
}
