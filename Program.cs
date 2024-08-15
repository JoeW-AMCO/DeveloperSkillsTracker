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
                        Console.WriteLine(dbUsername);
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

<<<<<<< Updated upstream
            //At this point I'll want to start using methods from classes such as devUser to handle making all of the variables
            //specific to the user to be displayed
            User user = new User(dbUsername);
            Console.WriteLine($"Welcome, {user.Username}!");
        }
=======
            Console.WriteLine($"Welcome, {currentUsername}! Pretty sure your id is {currentUserID}");

            List<DimSkill> skillsList;
            using (var context = new MyDbContext())
            {                
                skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
            }

            foreach (var skill in skillsList)
            {
                Console.WriteLine(skill.Skill_Name);
            }
            skillsList[0].DeleteUserAttribute(skillsList[0]);         
                
    }
>>>>>>> Stashed changes
    }
}
