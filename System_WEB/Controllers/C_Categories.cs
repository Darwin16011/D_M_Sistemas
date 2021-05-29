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
    public class CategoriesController : ControllerBase
    {
        private readonly DbContextSistema _context;
        public CategoriesController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        [HttpGet("{idcategories}")]
        public async Task<ActionResult<Categories>> GetCategories(int id)
        {
            var Categories = await _context.Categories.FindAsync(id);


            if (Categories == null)
            {
                return NotFound();
            }
            return Categories;
        }
        
        [HttpPut("idCategories")]
        public async Task<IActionResult> PutCategories(int id, Categories Categories)
        {
            
            if (id != Categories.idCategories)
            {
                return BadRequest();
            }
            _context.Entry(Categories).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (CategoriesExists(id))
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
        public async Task<ActionResult<Categories>> PostCategories(Categories Categories)
        {
            _context.Categories.Add(Categories);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCategories", new { id = Categories.idCategories }, Categories);
        }
        
        [HttpDelete("idCategories")]
        public async Task<ActionResult<Categories>> DeleteCategories(int id)
        {
            var Categories = await _context.Categories.FindAsync(id);
            if (Categories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(Categories);
            await _context.SaveChangesAsync();
            return Categories;
        }

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(z => z.idCategories == id);
        }
    }
}
