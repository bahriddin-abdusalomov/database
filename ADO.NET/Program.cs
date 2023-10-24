using System.Data.SqlClient;

public class Program
{
    public static void Main(string[] args)
    {
        using (SqlConnection connect = new SqlConnection())
        {
            connect.ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database = LessonDb; Trusted_Connection = True;";
            connect.Open();

            string query = "Select firstname from Persons";
            SqlCommand cmd = new SqlCommand(query, connect);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["firstname"]);
                }
            }

        }
    }
}




