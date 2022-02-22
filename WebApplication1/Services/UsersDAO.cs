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

            // Using the connection string we can connect to the server 
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                // This is a Constructor that instantiates the new Object
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // This is the command that GETS the datat from the SQL serevr
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                // This is a try catch block that Catches the error in case the server messed up
                try
                {
                    // This opens the server
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // This checks if the server
                    if (reader.HasRows)
                    {
                        sucess = true;
                    }
                } 
                // This is a catch block that catches the errors from the server
                catch (Exception e)
                {
                    // This catches the server error and writes it to the console
                    Console.WriteLine(e.Message);
                }
            }

            // This returns the varaible back to the function
            return sucess;
        }
    }
}
