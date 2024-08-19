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

            UserProfile profile = new UserProfile(userDetails.Username, userDetails.User_ID, skillsList, experiencesList, certificationsList);

            Console.Clear();

            string attributeChoice = Menus.TableViewer(context, profile);

            Console.Clear();

            string changeChoice = Menus.DataViewer(context, profile, attributeChoice);

            Console.Clear();

            if (changeChoice != "Exit")
            {
                if (changeChoice == "Add")
                {
                    Menus.AddMenu(context, profile, attributeChoice, changeChoice);
                }
                else if (changeChoice == "Delete")
                {
                    Menus.DeleteMenu(context, profile, attributeChoice, changeChoice);
                }
                else if (changeChoice == "Edit")
                {
                    Menus.EditMenu(context, profile, attributeChoice, changeChoice);
                }
            }
        }
    }
}
