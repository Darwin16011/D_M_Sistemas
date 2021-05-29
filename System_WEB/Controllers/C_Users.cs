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
    public class UsersController : ControllerBase
    {

        private readonly DbContextSistema _context;
        public UsersController(DbContextSistema context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [HttpGet("{idUser}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.Users.FindAsync(id);


            if (User == null)
            {
                return NotFound();
            }
            return User;
        }
        
        [HttpPut("idUser")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            
            if (id != User.idUser)
            {
                return BadRequest();
            }
            _context.Entry(User).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            
            
            catch (DbUpdateConcurrencyException)
            {
                if (UserExists(id))
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
        public async Task<ActionResult<User>> PostCategoria(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = User.idUser }, User);
        }
        

        [HttpDelete("idUser")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return User;
        }


        
        private bool UserExists(int id)
        {
            return _context.Users.Any(z => z.idUser == id);
        }
    }
}
