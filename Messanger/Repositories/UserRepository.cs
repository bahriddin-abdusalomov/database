using Messanger.Dtos;
using Messanger.Interfaces;
using Messanger.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace Messanger.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    public UserRepository()
    {
        this._connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = MessangerDb; Trusted_Connection = True;";
    }

    public async Task<int> CreateAsync(UserDto model)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Users(Name, Surname, Email, PhoneNumber, UserName," +
                                                "Created, Updated)" +
                                                " Values(@Name, " +
                                                        "@Surname, " +
                                                        "@Email, " +
                                                        "@PhoneNumber, " +
                                                        "@UserName, " +
                                                        "@Created, " +
                                                        "@Updated);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", model.FirstName);
            command.Parameters.AddWithValue("@Surname", model.LastName);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
            command.Parameters.AddWithValue("@UserName", model.UserName);
            command.Parameters.AddWithValue("@Created", DateTime.Now.ToString());
            command.Parameters.AddWithValue("@Updated", "10/26/2023 9:12:10 PM");

            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }

    public Task<int> DeepDeletedAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetAsync(string email)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Users WHERE Email = @Email";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", email);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                User employee = new User();
                if (reader.Read())
                {
                    employee.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    employee.FirstName = reader.GetString(reader.GetOrdinal("Name"));
                    employee.LastName = reader.GetString(reader.GetOrdinal("Surname"));
                    employee.Email = reader.GetString(reader.GetOrdinal("Email"));
                    employee.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                    employee.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    employee.Created = DateTime.Parse(reader.GetString(reader.GetOrdinal("Created")));
                    employee.Updated = DateTime.Parse(reader.GetString(reader.GetOrdinal("Updated")));
                }

                if (employee.Id == 0)
                    return new User();
                return employee;
            }
        }
    }

    public Task<int> UpdateAsync(int id, UserDto entity)
    {
        throw new NotImplementedException();
    }
}
