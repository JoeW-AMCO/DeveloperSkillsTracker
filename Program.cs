using DeveloperSkillsTracker.Database;
using System.Data;
using System.Linq;


namespace DeveloperSkillsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            

            string dbUsername = string.Empty;
            int dbUserID;
            Console.Write("Welcome to the Developer Skills Tracker!\n");                       

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: ");
                string password = Console.ReadLine() ?? string.Empty;
                //DataTable userTable = dbConnection.ExecuteQuery($"SELECT * FROM dbo.DimUser WHERE Username = '{username}' AND Password= '{password}'");

                try 
                {
                    using (var context = new MyDbContext())
                    {
                        var currentUser = context.Users
                                              .Where(u => u.Username == username && u.Password == password)
                                              .FirstOrDefault();

                        dbUsername = currentUser.Username;
                        dbUserID = currentUser.User_ID;
                        Console.WriteLine(dbUsername + " " + dbUserID);
                    }
                    

                    //dbUsername = (string)userTable.Rows[0]["Username"];
                    //string dbPassword = (string)userTable.Rows[0]["Password"];
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
            User user = new User(dbUserID, dbUsername);
            //Each attribute will need to be given a fk user id, title, and desc
            Skill testSkill = new Skill(user.UserID, "Making a new method", "This proves you're able to make a class method");
            Console.WriteLine($"Welcome, {user.Username}! Pretty sure your id is {user.UserID}");
            Console.WriteLine($"Your skill is {testSkill.AttributeName} with a description of {testSkill.AttributeDescription}");

            testSkill.AddUserAttribute(user.UserID, testSkill.AttributeName, testSkill.AttributeDescription);

            //Put this data into the db, then turn it into a function of the attribute class
        }
    }
}
