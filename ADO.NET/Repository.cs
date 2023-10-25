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
    }
}

