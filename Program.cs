using DeveloperSkillsTracker.Database;
using System.Data;
using System.Linq;


namespace DeveloperSkillsTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDbContext();
            List<DimUser> currentUser;
            List<DimSkill> skillsList;
            List<DimExperience> experiencesList;
            List<DimCertification> certificationsList;
            string currentUsername;
            int currentUserID;
            Console.Write("Welcome to the Developer Skills Tracker!\n");

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine() ?? string.Empty;
                Console.Write("Password: ");
                string password = Console.ReadLine() ?? string.Empty;

                var tryLogin = context.Users
                                        .Where(u => u.Username == username && u.Password == password)
                                        .FirstOrDefault();

                if (tryLogin != null && tryLogin.Username != null && tryLogin.Password != null)
                {
                    currentUsername = tryLogin.Username;
                    currentUserID = tryLogin.User_ID;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
            
            Console.WriteLine($"Welcome, {currentUsername}! Pretty sure your id is {currentUserID}");

            //Create list of skills
            //Give user list of skill ids for easy referencing
            //Pass skill id to change attribute, alongside new value parameters
            

            skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();

            foreach (var skill in skillsList)
            {
                Console.WriteLine(skill.Skill_ID + " " + skill.Skill_Name);
            }
            

            int chosenSkillId = 6;
            string newSkillName = "Updating with validation";
            string newSkillDescription = "Changing values";
            DimSkill.ChangeUserAttribute(currentUserID, chosenSkillId, newSkillName, newSkillDescription, context);

            
            //Need to add error handling/other logic to avoid issues when trying to delete when there are no skills etc
            //skillsList[0].AddUserAttribute(skillsList[0]);

            //Adding test
            /*DimSkill newSkill = new DimSkill
            {
                Skill_Name = "Refactoring",
                User_ID = currentUserID,
                Skill_Description = "Updating inheritance"
            };

            newSkill.AddUserAttribute(context);*/

        }
    }
}
