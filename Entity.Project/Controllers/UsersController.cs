using Entity.Project.Data;
using Entity.Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity.Project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        [HttpPost]
        public IActionResult Create(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("O'ta go'zal");
        }

        [HttpPut]
        public IActionResult Update(int id, UserDto user)
        {
            var userGet = _context.Users.FirstOrDefault(user => user.Id == id);

            userGet.Name = user.Name;
            userGet.Age = user.Age;

            _context.Users.Update(userGet);
            int result = _context.SaveChanges();
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == id);

            _context.Users.Remove(user);
            int result = _context.SaveChanges();    
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var user =  _context.Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
