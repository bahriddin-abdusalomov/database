using Messanger.Interfaces;
using Messanger.Models;
using System.Data.SqlClient;

namespace Messanger.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    public UserRepository()
    {
        this._connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = MessangerDb; Trusted_Connection = True;";
    }

    public async Task<int> CreateAsync(User model)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Users(id, firstname, lastname,email,phonenumber)" +
                " Values(@Id, " +
                                                    "@FirstName, " +
                                                    "@LastName, " +
                                                    "@Email, " +
                                                    "@PhoneNumber);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", model.Id);
            command.Parameters.AddWithValue("@FirstName", model.FirstName);
            command.Parameters.AddWithValue("@LastName", model.LastName);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);

            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }

    public Task<int> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByIdAsync(string email)
    {
        using(SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Users WHERE Email = @Email";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", email);       

            using(SqlDataReader reader = command.ExecuteReader()) 
            {
                User user = new User();
                if(reader.Read())
                {
                    user.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                    user.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    user.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    user.Email = reader.GetString(reader.GetOrdinal("Email"));
                    user.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));

                }
                    if (user is null)
                        return new User();
                    return user;
            }
        }
    }

    public Task<int> UpdateAsync(Guid id, User model)
    {
        throw new NotImplementedException();
    }
}
