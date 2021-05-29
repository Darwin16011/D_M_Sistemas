using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D_M_Sistemas.Datos;
using D_M_Sistemas.Entidades.Ventas;
using D_M_Sistemas.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_M_Sistemas.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public classVenta_DetailController : Controller
    {
        private readonly DbContextSistema _context;
        publicVenta_DetailController(DbContextSistema context)
        {
            _context = context;
        }
   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta_Detail>>> GetVenta_Details()
        {
            return await _context.Venta_Details.ToListAsync();
        }

        
        [HttpGet("{idVenta_Detail}")]
        public async Task<ActionResult<Venta_Detail>> GetVenta_Detail(int id)
        {
            var Venta_Detail = await _context.Venta_Details.FindAsync(id);


            if (Venta_Detail == null)
            {
                return NotFound();
            }
            return Venta_Detail;
        }
        
        [HttpPut("idVenta_Detail")]
        public async Task<IActionResult> PutVenta_Detail(int id, Venta_Detail Venta_Detail)
        {
            
            if (id != Venta_Detail.idVenta_Detail)
            {
                return BadRequest();
            }
            _context.Entry(Venta_Detail).State = EntityState.Modified;
        
            try
            {
                await _context.SaveChangesAsync();
            }
         
            catch (DbUpdateConcurrencyException)
            {
                if (Venta_DetailExists(id))
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
        public async Task<ActionResult<Venta_Detail>> PostVenta_Detail(Venta_Detail Venta_Detail)
        {
            _context.Venta_Details.Add(Venta_Detail);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta_Detail", new { id = Venta_Detail.idVenta_Detail }, Venta_Detail);
        }

        [HttpDelete("idVenta_Detail")]
        public async Task<ActionResult<Venta_Detail>> DeleteVenta_Detail(int id)
        {
            var Venta_Detail = await _context.Venta_Details.FindAsync(id);
            if (Venta_Detail == null)
            {
                return NotFound();
            }
            _context.Venta_Details.Remove(Venta_Detail);
            await _context.SaveChangesAsync();
            return Venta_Detail;
        }


        
        private bool Venta_DetailExists(int id)
        {
            return _context.Venta_Details.Any(z => z.idVenta_Detail == id);
        }
    }
}
