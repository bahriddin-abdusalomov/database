//using System.Data.SqlClient;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        using (SqlConnection connect = new SqlConnection())
//        {
//            connect.ConnectionString = "Server = (localdb)\\MSSQLLocalDB; Database = LessonDb; Trusted_Connection = True;";
//            connect.Open();

//            string query = "Select firstname from Persons";
//            SqlCommand cmd = new SqlCommand(query, connect);

//            using (SqlDataReader reader = cmd.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    Console.WriteLine(reader["firstname"]);
//                }
//            }

//        }
//    }
//}

//using ADO.NET;

//Repository repository = new Repository();

////repository.GetByIdAsync(2);

//Users users = new Users()
//{
//    Id = 4,
//    FirstName = "Bahriddin",
//    LastName = "Abdusalomov",
//    Age = 20
//};

//repository.Insert(users);


DateTime dateTime = DateTime.Now;

Console.WriteLine(dateTime);

//SQL Injection, web ilovalarda va ma'lumotlar bazasiga so'rov yuborishda xatolikni topish uchun 
//    ishlatiladigan amaldir.