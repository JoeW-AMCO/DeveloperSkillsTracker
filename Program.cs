using DeveloperSkillsTracker.Database;
using System.Data;
using System.Linq;


namespace DeveloperSkillsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DimUser> currentUser;
            string currentUsername;
            int currentUserID;
            Console.Write("Welcome to the Developer Skills Tracker!\n");

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: ");
                string password = Console.ReadLine() ?? string.Empty;

                using (var context = new MyDbContext())
                {
                    var tryLogin = context.Users
                                            .Where(u => u.Username == username && u.Password == password)
                                            .FirstOrDefault();
                    if (tryLogin != null && tryLogin.Username != null && tryLogin.Password != null)
                    {
                        /*currentUser = context.Users
                        .Where(u => u.Username == username).ToList();*/
                        currentUsername = tryLogin.Username;
                        currentUserID = tryLogin.User_ID;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                    }
                }
            }

            Console.WriteLine($"Welcome, {currentUsername}! Pretty sure your id is {currentUserID}");

            List<DimSkill> skillsList;
            using (var context = new MyDbContext())
            {
                skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
                //context.Skills.

            }

            foreach (var skill in skillsList)
            {
                Console.WriteLine(skill.Skill_Name);
            }
            //Need to add error handling/other logic to avoid issues when trying to delete when there are no skills etc
            //skillsList[0].AddUserAttribute(skillsList[0]);

            DimSkill newSkill = new DimSkill
            {
                Skill_Name = "C#",
                User_ID = currentUserID,
                Skill_Description = "Struggling"
            };
            newSkill.AddUserAttribute(newSkill);

        }
    }
}
