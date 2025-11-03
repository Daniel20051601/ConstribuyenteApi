using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConstribuyenteApi.Contribuyente.Dal;
using ConstribuyenteApi.Contribuyente.Models;

namespace ConstribuyenteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly Contexto _context;

        public ContribuyentesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Contribuyentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribuyentes>>> GetContribuyentes()
        {
            return await _context.Contribuyentes.ToListAsync();
        }

        // GET: api/Contribuyentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribuyentes>> GetContribuyentes(int id)
        {
            var contribuyentes = await _context.Contribuyentes.FindAsync(id);

            if (contribuyentes == null)
            {
                return NotFound();
            }

            return contribuyentes;
        }

        // PUT: api/Contribuyentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribuyentes(int id, Contribuyentes contribuyentes)
        {
            if (id != contribuyentes.id)
            {
                return BadRequest();
            }

            _context.Entry(contribuyentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContribuyentesExists(id))
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

        // POST: api/Contribuyentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contribuyentes>> PostContribuyentes(Contribuyentes contribuyentes)
        {
            _context.Contribuyentes.Add(contribuyentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContribuyentes", new { id = contribuyentes.id }, contribuyentes);
        }

        // DELETE: api/Contribuyentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribuyentes(int id)
        {
            var contribuyentes = await _context.Contribuyentes.FindAsync(id);
            if (contribuyentes == null)
            {
                return NotFound();
            }

            _context.Contribuyentes.Remove(contribuyentes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContribuyentesExists(int id)
        {
            return _context.Contribuyentes.Any(e => e.id == id);
        }
    }
}
