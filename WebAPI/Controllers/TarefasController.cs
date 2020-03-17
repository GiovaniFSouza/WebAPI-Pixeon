using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly PixeonContext _context;

        public TarefasController(PixeonContext context)
        {
            _context = context;
        }

        // GET: api/Tarefas
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<Tarefas>>> GetTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        // GET: api/Tarefas/5
        [HttpGet("{id}")]
        //[Route("Obter")]
        public async Task<ActionResult<Tarefas>> GetTarefas(int id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);

            if (tarefas == null)
            {
                return NotFound();
            }

            return tarefas;
        }

        // PUT: api/Tarefas/5
        [HttpPut("{id}")]
        //[Route("Update")]
        public async Task<IActionResult> PutTarefas(int id, Tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarefas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefasExists(id))
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

        // POST: api/Tarefas
        [HttpPost]
        //[Route("Add")]
        public async Task<ActionResult<Tarefas>> PostTarefas(Tarefas tarefas)
        {
            _context.Tarefas.Add(tarefas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarefas", new { id = tarefas.Id }, tarefas);
        }

        // DELETE: api/Tarefas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefas>> DeleteTarefas(int id)
        {
            var tarefas = await _context.Tarefas.FindAsync(id);
            if (tarefas == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(tarefas);
            await _context.SaveChangesAsync();

            return tarefas;
        }

        private bool TarefasExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
