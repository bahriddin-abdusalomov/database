using Project.WebApi.Dtos;
using Project.WebApi.Interfaces;
using Project.WebApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Project.WebApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;
    public EmployeeRepository()
    {
        this._connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = CompanyDb; Trusted_Connection = True;";
    }

    public async Task<int> CreateAsync(EmployeeDto model)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Employees(Name, Surname, Email, Login, Password," +
                                                " Status, Role, Created, Updated, Deleted)" +
                                                " Values(@Name, " +
                                                        "@Surname, " +
                                                        "@Email, " +
                                                        "@Login, " +
                                                        "@Password, " +
                                                        "@Status, " +
                                                        "@Role, " +
                                                        "@Created, " +
                                                        "@Updated, " +
                                                        "@Deleted);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Surname", model.Surname);
            command.Parameters.AddWithValue("@Email", model.Email);
            command.Parameters.AddWithValue("@Login", model.Login);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Status", model.Status);
            command.Parameters.AddWithValue("@Role", model.Role);
            command.Parameters.AddWithValue("@Created", DateTime.Now.ToString());
            command.Parameters.AddWithValue("@Updated", " ");
            command.Parameters.AddWithValue("@Deleted", " ");


            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }

    public async Task<int> DeepDeletedAsync(int id)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Employees WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> GetAsync(int id)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                EmployeeDto employee = new EmployeeDto();
                if (reader.Read())
                {
                    employee.Name = reader.GetString(reader.GetOrdinal("Name"));
                    employee.Surname = reader.GetString(reader.GetOrdinal("Surname"));
                    employee.Email = reader.GetString(reader.GetOrdinal("Email"));
                    employee.Login = reader.GetString(reader.GetOrdinal("Login"));
                    employee.Password = reader.GetString(reader.GetOrdinal("Password"));
                }

                if (employee is null)
                    return new EmployeeDto();
                return employee;
            }
        }
    }

    public async Task<int> UpdateAsync(int id, EmployeeDto entity)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string query1 = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand command1 = new SqlCommand(query1, connection);

            command1.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command1.ExecuteReader())
            {
                EmployeeDto employee = new EmployeeDto();
                if (reader.Read())
                {
                    employee.Name = reader.GetString(reader.GetOrdinal("Name"));
                    employee.Surname = reader.GetString(reader.GetOrdinal("Surname"));
                    employee.Email = reader.GetString(reader.GetOrdinal("Email"));
                    employee.Login = reader.GetString(reader.GetOrdinal("Login"));
                    employee.Password = reader.GetString(reader.GetOrdinal("Password"));
                }


                string query2 = "UPDATE Employees SET Name = @Name, Surname = @Surname, " +
                                    "Email = @Email, Login = @Login, Password = @Password," +
                                    " Status = @Status, Role = @Role WHERE Id = @Id";

                SqlCommand command2 = new SqlCommand(query2, connection);

                command2.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
                command2.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = employee.Surname;
                command2.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
                command2.Parameters.Add("@Login", SqlDbType.NVarChar).Value = employee.Login;
                command2.Parameters.Add("@Password", SqlDbType.NVarChar).Value = employee.Password;
                command2.Parameters.Add("@Status", SqlDbType.Int).Value = (int)employee.Status;
                command2.Parameters.Add("@Role", SqlDbType.Int).Value = (int)employee.Role;

                int rowsAffected = command2.ExecuteNonQuery();

                return rowsAffected;
            }
        }
    }
}
