using System.Data;
using System.Data.SqlClient;

namespace ADO.NET
{
    public class Repository : IRepository<Users>
    {
        private readonly string _connectionString;

        public Repository()
        {
            _connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = LessonDb; Trusted_Connection = True;";
        }

        public void GetByIdAsync(int id)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = _connectionString;
                connect.Open();

                string query = $"Select * from Others Where Id = {id}";
                SqlCommand cmd = new SqlCommand(query, connect);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}  {reader["firstname"]}   {reader["lastname"]}    {reader["age"]}");
                    }
                }

            }
        }

        public void Insert(Users model)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = _connectionString;
                connect.Open();

                string query = $"insert into Others('Id', 'FirstName', 'LastName', 'Age') values('{model.Id}', '{model.FirstName}', '{model.LastName}', '{model.Age}');";
                SqlCommand cmd = new SqlCommand(query, connect);

                using(SqlDataReader reader = cmd.ExecuteReader()) { }
            }
        }

        public bool InsertData(string tableName, string data)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))         
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"INSERT INTO {tableName} VALUES (@Data)";
                    cmd.Parameters.AddWithValue("@Data", data);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
