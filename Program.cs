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
            
            string currentUsername;
            int currentUserID;
            AnsiConsole.Write(
                new FigletText("Developer Skills Tracker").Centered().Color(Color.RosyBrown));
            AnsiConsole.Markup("\n[sandybrown]Welcome to the Developer Skills Tracker! Please enter your login details below.[/]\n\n");

            DimUser userDetails = Menus.MainMenu(context);
            currentUsername = userDetails.Username;
            currentUserID = userDetails.User_ID;

            List<DimSkill> skillsList = context.Skills.Where(s => s.User_ID == currentUserID).ToList();
            List<DimExperience> experiencesList = context.Experiences.Where(e => e.User_ID == currentUserID).ToList();
            List<DimCertification> certificationsList = context.Certifications.Where(c => c.User_ID == currentUserID).ToList();

            Console.Clear();

            string userChoice = Menus.TableViewer(context, currentUsername, currentUserID, skillsList, experiencesList, certificationsList);

            Console.Clear();

            switch (userChoice)
            {
                case "Skills":
                    Console.WriteLine("Here are your skills: ");
                    foreach (var skill in skillsList)
                    {
                        Console.WriteLine("Skill Name: " + skill.Skill_Name + " - Skill Description: " + skill.Skill_Description + " - Skill ID: " + skill.Skill_ID);
                    }

                    var skillDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Would you like to add, delete, or edit a skill?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));
                    //Jumping the gun here, this goes straight to choosing a skill, before asking about adding a new one
                    UserProfile.AlterMenu(skillsList);
                    break;
                case "Experiences":
                    UserProfile.AlterMenu(experiencesList);
                    break;
                case "Certifications":
                    UserProfile.AlterMenu(certificationsList);
                    break;
                case "Exit":
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }
    }
}
