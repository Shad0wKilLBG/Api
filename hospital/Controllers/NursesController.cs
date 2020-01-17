using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hospital.Data;
using hospital.Models;

namespace hospital.Controllers
{
    [Route("api/nurses")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly HospitalDBContext _context;

        public NursesController(HospitalDBContext context)
        {
            _context = context;
        }

        // GET: api/Nurses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
            return await _context.Nurses.ToListAsync();
        }

        // GET: api/Nurses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

        // PUT: api/Nurses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> PutNurse(int id, Nurse nurse)
        {
            if (id != nurse.Id)
            {
                return BadRequest();
            }

            _context.Entry(nurse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
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

        // POST: api/Nurses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Nurse>> PostNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurse", new { id = nurse.Id }, nurse);
        }

        // DELETE: api/Nurses/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Nurse>> DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return nurse;
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.Id == id);
        }
    }
}
