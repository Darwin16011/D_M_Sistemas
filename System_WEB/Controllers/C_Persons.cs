using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using D_M_Sistemas.Datos;
using D_M_Sistemas.Entidades.Users;
using D_M_Sistemas.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D_M_Sistemas.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly DbContextSistema _context;
        public PersonsController(DbContextSistema context)
        {
            _context = context;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        
        [HttpGet("{idPersons}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);


            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        
        [HttpPut("idPersons")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
           
            if (id != person.idPersons)
            {
                return BadRequest();
            }
            _context.Entry(person).State = EntityState.Modified;
          
            try
            {
                await _context.SaveChangesAsync();
            }
          
            catch (DbUpdateConcurrencyException)
            {
                if (PersonExists(id))
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
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPerson", new { id = person.idPersons }, person);
        }
        

        [HttpDelete("idPersons")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }


        
        private bool PersonExists(int id)
        {
            return _context.Persons.Any(z => z.idPersons == id);
        }
    }
}