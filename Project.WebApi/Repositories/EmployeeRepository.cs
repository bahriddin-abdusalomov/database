using Project.WebApi.Dtos;
using Project.WebApi.Enums;
using Project.WebApi.Interfaces;
using Project.WebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace Project.WebApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;
    public EmployeeRepository()
    {
        this._connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = CompanyDb; Trusted_Connection = True;";
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

    public async Task<int> DeleteAsync(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string query = "UPDATE Employees SET Deleted = @Deleted, Status = @Status WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status.Deleted.ToString();
            command.Parameters.Add("@Deleted", SqlDbType.NVarChar).Value = DateTime.Now.ToString();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }
    }

    public async Task<int> UpdateAsync(int id, EmployeeDto employee)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string query = "UPDATE Employees SET Name = @Name, Surname = @Surname, " +
                                "Email = @Email, Login = @Login, Password = @Password," +
                                " Status = @Status, Role = @Role, Updated = @Updated WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = employee.Name;
            command.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = employee.Surname;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = employee.Email;
            command.Parameters.Add("@Login", SqlDbType.NVarChar).Value = employee.Login;
            command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = employee.Password;
            command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status.Updated.ToString();
            command.Parameters.Add("@Role", SqlDbType.Int).Value = (int)employee.Role;
            command.Parameters.Add("@Updated", SqlDbType.NVarChar).Value = DateTime.Now.ToString();

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Employee> employees = new List<Employee>();
                int index = 0;

                while (reader.Read())
                {
                    Employee employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Email = reader["Email"].ToString(),
                        Login = reader["Login"].ToString(),
                        Password = reader["Password"].ToString(),
                        Status = reader["Status"].ToString(),
                        Role = reader["Role"].ToString(),
                        Created = Convert.ToDateTime(reader["Created"]),
                        Updated = Convert.ToDateTime(reader["Updated"]),
                        Deleted = Convert.ToDateTime(reader["Deleted"])
                    };
                    employees.Add(employee);

                }

                employees = employees.Where(employee => employee.Status != "Deleted").ToList();

                if (employees is null)
                    return new List<Employee>();
                return employees;
            }
        }
    }

    public async Task<Employee> GetAsync(int id)
    {
        using (SqlConnection connection = new SqlConnection(this._connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                Employee employee = new Employee();
                if (reader.Read())
                {
                    employee.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    employee.Name = reader.GetString(reader.GetOrdinal("Name"));
                    employee.Surname = reader.GetString(reader.GetOrdinal("Surname"));
                    employee.Email = reader.GetString(reader.GetOrdinal("Email"));
                    employee.Login = reader.GetString(reader.GetOrdinal("Login"));
                    employee.Password = reader.GetString(reader.GetOrdinal("Password"));
                    employee.Status = reader.GetString(reader.GetOrdinal("Status"));
                    employee.Role = reader.GetString(reader.GetOrdinal("Role"));
                    employee.Created = DateTime.Parse(reader.GetString(reader.GetOrdinal("Created")));
                    employee.Updated = DateTime.Parse(reader.GetString(reader.GetOrdinal("Updated")));
                    employee.Deleted = DateTime.Parse(reader.GetString(reader.GetOrdinal("Deleted")));
                }

                if (employee is null || employee.Status == "Deleted")
                    return new Employee();
                return employee;
            }
        }
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
            command.Parameters.AddWithValue("@Status", Status.Created.ToString());
            command.Parameters.AddWithValue("@Role", model.Role);
            command.Parameters.AddWithValue("@Created", DateTime.Now.ToString());
            command.Parameters.AddWithValue("@Updated", "10/26/2023 9:12:10 PM");
            command.Parameters.AddWithValue("@Deleted", "10/26/2023 9:12:10 PM");


            int affectedRows = command.ExecuteNonQuery();

            return affectedRows;
        }
    }
}


