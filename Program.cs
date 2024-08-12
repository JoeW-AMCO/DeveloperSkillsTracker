using System.Data;
namespace DeveloperSkillsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnector dbConnection = new SqlConnector();
            string dbUsername = string.Empty;
            Console.Write("Welcome to the Developer Skills Tracker!\n");                       

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: ");
                string password = Console.ReadLine() ?? string.Empty;
                DataTable userTable = dbConnection.ExecuteQuery($"SELECT * FROM dbo.DimUser WHERE Username = '{username}' AND Password= '{password}'");

                try 
                {
                    dbUsername = (string)userTable.Rows[0]["Username"];
                    string dbPassword = (string)userTable.Rows[0]["Password"];
                    break;
                }
                //userTable.Rows[0]["userName"] != "" && userTable.Rows[0]["userName"] != "")
                catch
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }               
            }

            //At this point I'll want to start using methods from classes such as devUser to handle making all of the variables
            //specific to the user to be displayed
            User user = new User(dbUsername);
            Console.WriteLine($"Welcome, {user.Username}!");
        }
    }
}
