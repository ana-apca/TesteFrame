using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteFrame.Data;

namespace TesteFrame.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class VitrineController : ControllerBase
    {

        private readonly AppDbContext _context;

        public VitrineController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Vitrine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vitrine>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Vitrine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vitrine>> GetVitrine(int id)
        {
            var vitrine = await _context.Produtos.FindAsync(id);

            if (vitrine == null)
            {
                return NotFound();
            }

            return vitrine;
        }

        // PUT: api/Vitrine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutVitrine(int id, Vitrine vitrine)
        {
            if (id != vitrine.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(vitrine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitrineExists(id))
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

        // POST: api/Vitrine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<Vitrine>> PostVitrine(Vitrine vitrine)
        {
            _context.Produtos.Add(vitrine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVitrine", new { id = vitrine.Codigo }, vitrine);
        }

        // DELETE: api/Vitrine/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteVitrine(int id)
        {
            var vitrine = await _context.Produtos.FindAsync(id);
            if (vitrine == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(vitrine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Vitrine/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("AtualizarEstoque/{id}")]
        public async Task<IActionResult> AtualizarEstoque(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            if (produto.Quantidade == 0)
            {
                return BadRequest(); // colocar msg indisponivel
            }
            produto.Quantidade--;

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitrineExists(id))
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

        private bool VitrineExists(int id)
        {
            return _context.Produtos.Any(e => e.Codigo == id);
        }
    }
}
