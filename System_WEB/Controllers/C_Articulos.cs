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
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public ArticulosController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulos>>> GetArticulos()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpGet("{idArticulos}")]
        public async Task<ActionResult<Articulos>> GetArticulos(int id)
        {
            var Articulos = await _context.Articulos.FindAsync(id);


            if (Articulos == null)
            {
                return NotFound();
            }
            return Articulos;
        }

        [HttpPut("idArticulos")]
        public async Task<IActionResult> PutArticulos(int id, Articulos Articulos)
        {

            if (id != Articulos.idArticulos)
            {
                return BadRequest();
            }
            _context.Entry(Articulos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }


            {
                if (ArticulosExists(id))
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
        public async Task<ActionResult<Articulos>> PostCategories(Articulos Articulos)
        {
            _context.Articulos.Add(Articulos);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetArticulos", new { id = Articulos.idArticulos }, Articulos);
        }


        [HttpDelete("idArticulos")]
        public async Task<ActionResult<Articulos>> DeleteArticulos(int id)
        {
            var Articulos = await _context.Articuloss.FindAsync(id);
            if (Articulos == null)
            {
                return NotFound();
            }
            _context.Articulos.Remove(Articulos);
            await _context.SaveChangesAsync();
            return Articulos;
        }



        private bool ArticulosExists(int id)
        {
            return _context.Articulos.Any(z => z.idArticulos == id);
        }
    }
}
