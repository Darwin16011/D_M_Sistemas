using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D_M_Sistemas.Datos;
using D_M_Sistemas.Entidades.Compras;
using D_M_Sistemas.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_M_Sistemas.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : Controller
    {
        private readonly DbContextSistema _context;
        public ComprasController(DbContextSistema context)
        {
            _context = context;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compras>>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }

        //SI QUIERO TRAER SOLO UNO O EL ID GT/API/Compras/EJEMPLO2
        [HttpGet("{idCompras}")]
        public async Task<ActionResult<Compras>> GetCompras(int id)
        {
            var Compras = await _context.Compras.FindAsync(id);


            if (Compras == null)
            {
                return NotFound();
            }
            return Compras;
        }

        [HttpPut("idCompras")]
        public async Task<IActionResult> PutCompras(int id, Compras Compras)
        {
        
            if (id != Compras.idCompras)
            {
                return BadRequest();
            }
            _context.Entry(Compras).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }
           
            catch (DbUpdateConcurrencyException)
            {
                if (ComprasExists(id))
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

       

        [HttpPost]
        public async Task<ActionResult<Compras>> PostCompras(Compras Compras)
        {
            _context.Compras.Add(Compras);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompras", new { id = Compras.idCompras }, Compras);
        }
    
        [HttpDelete("idCompras")]
        public async Task<ActionResult<Compras>> DeleteCompras(int id)
        {
            var Compras = await _context.Compras.FindAsync(id);
            if (Compras == null)
            {
                return NotFound();
            }
            _context.Compras.Remove(Compras);
            await _context.SaveChangesAsync();
            return Compras;
        }


        
        private bool ComprasExists(int id)
        {
            return _context.Compras.Any(z => z.idCompras == id);
        }
    }
}
