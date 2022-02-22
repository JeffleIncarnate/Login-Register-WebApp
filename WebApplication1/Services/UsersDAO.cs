using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Services
{
    //This is the Users class
    public class UsersDAO
    {
        //Connection String for the SQL server, this server could be running on the other side of the world and it'd still work
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Main;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        // This is a Method that will return a true or false var so we can access the Server 
        public bool FindUderByNameAndPassword(UserModel user)
        {
            // This is the bool that'll be returned true or false
            bool sucess = false;

           // This is the SQL statement in a varaible so we dont need to type it out over and over again
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        sucess = true;
                    }
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return sucess;
        }
    }
}
