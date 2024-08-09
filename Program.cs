using System.Data;
namespace DeveloperSkillsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnector dbConnection = new SqlConnector();
            Console.Write("Welcome to the Developer Skills Tracker!\n");                       

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                DataTable userTable = dbConnection.ExecuteQuery($"SELECT * FROM dbo.devUser WHERE userName = '{username}' AND userPass= '{password}'");

                try 
                {
                    string dbUsername = (string)userTable.Rows[0]["userName"];
                    string dbPassword = (string)userTable.Rows[0]["userPass"];
                    break;
                }
                //userTable.Rows[0]["userName"] != "" && userTable.Rows[0]["userName"] != "")
                catch
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }

            //devUser user = new devUser(username);
        }
    }
}
