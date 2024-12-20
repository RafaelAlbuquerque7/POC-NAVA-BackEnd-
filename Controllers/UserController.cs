using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class UserController : ControllerBase
 {
     private readonly ApplicationDbContext _context;

     public UserController(ApplicationDbContext context)
     {
         _context = context;
     }

     // Cadastrar usuário
     [HttpPost]
     public async Task<IActionResult> CreateUser(User user)
     {
         _context.Users.Add(user);
         await _context.SaveChangesAsync();
         return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
     }

     // Listar todos os usuários
     [HttpGet]
     public async Task<IActionResult> GetUsers()
     {
         var users = await _context.Users.ToListAsync();
         return Ok(users);
     }

     // Obter um usuário por ID
     [HttpGet("{id}")]
     public async Task<IActionResult> GetUser(int id)
     {
         var user = await _context.Users.FindAsync(id);
         if (user == null)
         {
             return NotFound();
         }
         return Ok(user);
     }

     // Atualizar um usuário
     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateUser(int id, User user)
     {
         if (id != user.Id)
         {
             return BadRequest();
         }

         _context.Entry(user).State = EntityState.Modified;
         await _context.SaveChangesAsync();

         return NoContent();
     }

     // Remover um usuário
     [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteUser(int id)
     {
         var user = await _context.Users.FindAsync(id);
         if (user == null)
         {
             return NotFound();
         }

         _context.Users.Remove(user);
         await _context.SaveChangesAsync();

         return NoContent();
     }
 }
}