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


    public class VentasController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public VentasController(DbContextSistema context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        
        [HttpGet("{idVenta}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);


            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }
     
        [HttpPut("idVenta")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
           
            if (id != venta.idVenta)
            {
                return BadRequest();
            }
            _context.Entry(venta).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            
            catch (DbUpdateConcurrencyException)
            {
                if (VentaExists(id))
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
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVenta", new { id = venta.idVenta }, venta);
        }
       

        [HttpDelete("idVenta")]
        public async Task<ActionResult<Venta>> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
            return venta;
        }


   
        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(z => z.idVenta == id);
        }
    }
}