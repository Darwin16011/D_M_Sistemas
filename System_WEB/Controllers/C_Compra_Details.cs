using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D_M_Sistemas.Datos;
using D_M_Sistemas.Entidades.Comprar;
using D_M_Sistemas.Entidades.;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_M_Sistemas.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Compra_DetailsController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public Compra_DetailsController(DbContextSistema context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra_Details>>> GetCompra_Details()
        {
            return await _context.Compra_Details.ToListAsync();
        }

     
        [HttpGet("{idCompra_Details}")]
        public async Task<ActionResult<Compra_Details>> GetCompra_Details(int id)
        {
            var Compra_Details = await _context.Compra_Details.FindAsync(id);


            if (Compra_Details == null)
            {
                return NotFound();
            }
            return Compra_Details;
        }
        
        [HttpPut("idCompra_Details")]
        public async Task<IActionResult> PutCompra_Details(int id, Compra_Details Compra_Details)
        {
            
            if (id != Compra_Details.idCompra_Details)
            {
                return BadRequest();
            }
            _context.Entry(Compra_Details).State = EntityState.Modified;
         
            try
            {
                await _context.SaveChangesAsync();
            }
            
            catch (DbUpdateConcurrencyException)
            {
                if (Compra_DetailsExists(id))
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
        public async Task<ActionResult<Compra_Details>> PostCategories(Compra_Details Compra_Details)
        {
            _context.Compra_Details.Add(Compra_Details);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompra_Details", new { id = Compra_Details.idCompra_Details }, Compra_Details);
        }
       
        [HttpDelete("idCompra_Details")]
        public async Task<ActionResult<Compra_Details>> DeleteCategories(int id)
        {
            var Compra_Details = await _context.Compra_Details.FindAsync(id);
            if (Compra_Details == null)
            {
                return NotFound();
            }
            _context.Compra_Details.Remove(Compra_Details);
            await _context.SaveChangesAsync();
            return Compra_Details;
        }


        private bool Compra_DetailsExists(int id)
        {
            return _context.Compra_Details.Any(z => z.idCompra_Details == id);
        }
    }
}