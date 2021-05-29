using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D_M_Sistemas.Datos;
using D_M_Sistemas.Entidades.Users;
using D_M_Sistemas.Entidades.Wherehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_M_Sistemas.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RolsController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public RolsController(DbContextSistema context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRols()
        {
            return await _context.Rols.ToListAsync();
        }


        [HttpGet("{idRol}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);


            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }
        
        [HttpPut("idRol")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            
            if (id != rol.idRol)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
           
            catch (DbUpdateConcurrencyException)
            {
                if (RolExists(id))
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
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRol", new { id = rol.idRol }, rol);
        }
    

        [HttpDelete("idRol")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            _context.Rols.Remove(rol);
            await _context.SaveChangesAsync();
            return rol;
        }


       
        private bool RolExists(int id)
        {
            return _context.Rols.Any(z => z.idRol == id);
        }
    }
}
