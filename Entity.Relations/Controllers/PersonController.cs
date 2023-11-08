using Entity.Relations.Data;
using Entity.Relations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity.Relations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public PersonController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("Person")]
        public async ValueTask<IActionResult> CreatePersonAsync(string name)
        {
            Person person = new Person()
            {
                Name = name
            };

            await _dbContext.Persons.AddAsync(person);
            int result = await _dbContext.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost("Car")]
        public async ValueTask<IActionResult> CreateCarAsync(string name)
        {
            Cars car = new Cars()
            {
                Name = name
            };

            await _dbContext.Cars.AddAsync(car);
            int result = await _dbContext.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost("PersonCars")]
        public async ValueTask<IActionResult> CreatePersonCarsAsync(int carId, int personId)
        {
            var person = _dbContext.Persons.FirstOrDefault(person => person.Id == personId);
            var car = _dbContext.Cars.FirstOrDefault(person => person.Id == carId);

            PersonCars personCars = new PersonCars()
            {
                PersonId = person.Id,
                CarsId = car.Id
            };

            await _dbContext.PersonCars.AddAsync(personCars);
            int result = await _dbContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var result = await _dbContext.Persons
                .Include(x => x.PersonCars)
                .ThenInclude(x => x.Cars)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("Car")]
        public async ValueTask<IActionResult> GetAllCarsAsync()
        {
            var result = await _dbContext.Cars.ToListAsync();

            return Ok(result);
        }

        [HttpGet("Person")]
        public async ValueTask<IActionResult> GetAllPersonAsync()
        {
            var result = await _dbContext.Persons.ToListAsync();

            return Ok(result);
        }
    }
}