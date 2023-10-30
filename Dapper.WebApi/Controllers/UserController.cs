using Dapper.WebApi.Dtos;
using Dapper.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("Connect");

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserDto user)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"Insert into Users Values('{user.Name}', '{user.Age}');";
                int result = connection.Execute(query);

                return Ok(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            using(SqlConnection connect = new SqlConnection(connectionString))
            {
                string query = "Select * From Users;";

                var user = connect.Query<User>(query);
                return Ok(user);
            }

        }

        [HttpGet("twoTable")]
        public async Task<IActionResult> TwoTableAsync()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Users;" +
                    "Select * from  Register";

                var twoTable = await connection.QueryMultipleAsync(query);

                var users = twoTable.ReadAsync<User>().Result;
                var registers = twoTable.ReadAsync<Register>().Result;

                return Ok(registers);
            }   
        }


    }
}
