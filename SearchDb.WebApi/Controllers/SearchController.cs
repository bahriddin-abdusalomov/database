using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchDb.WebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace SearchDb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("Connect");

        [HttpGet]
        public IActionResult SearchValue(string searchStr)
        {
            using ( SqlConnection connection = new SqlConnection(connectionString))
            {
                    string query = $"EXEC SearchProcedure {searchStr}";
                    var result = connection.Query<Search>(query);
                     return Ok(result);
            }

        }
    }
}
