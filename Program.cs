using DeveloperSkillsTracker.Database;
using System.Data;
using System.Linq;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            AnsiConsole.Write(
                new FigletText("Developer Skills Tracker").Centered().Color(Color.RosyBrown));
            AnsiConsole.Markup("\n[sandybrown]Welcome to the Developer Skills Tracker! Please enter your login details below.[/]\n\n");

            

            

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

            Console.Clear();            
            AnsiConsole.MarkupLine($"[sandybrown]Welcome back, {currentUsername}! Here's your current profile.[/]");                  

            skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
            experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
            certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();
            
            UserProfile currentUserProfile = new UserProfile(currentUserID, skillsList, experiencesList, certificationsList);
            currentUserProfile.GenerateProfileTable(skillsList, experiencesList, certificationsList);            
            

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What table would you like to make changes to?")
                .PageSize(10)
                .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                .AddChoices(new[] { "Skills", "Experiences", "Certifications" }));
            Console.Clear();


            //Three paths, but all lead to same function, just on something different
            //Selecting 

            switch (userChoice)
            {
                case "Skills":
                    //skill.AddUserAttribute(context);
                    break;
                case "Experiences":
                    //experience.AddUserAttribute(context);
                    break;
                case "Certifications":
                    //certification.AddUserAttribute(context);
                    break;
            }








            /*int chosenSkillId = 6;
            string newSkillName = "Updating with validation";
            string newSkillDescription = "Changing values";
            DimSkill.ChangeUserAttribute(currentUserID, chosenSkillId, newSkillName, newSkillDescription, context);*/

            
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
