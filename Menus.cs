using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperSkillsTracker.Database;
using Spectre.Console;

namespace DeveloperSkillsTracker
{
    internal class Menus
    {
        public static DimUser MainMenu(MyDbContext context)
        {
            string currentUsername;
            int currentUserID;

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
                    return tryLogin;                    
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }                
            }            
        }

        public static string TableViewer(MyDbContext context, string currentUsername, int currentUserID, List<DimSkill> skillsList, List<DimExperience> experiencesList, List<DimCertification> certificationsList)
        {            
            AnsiConsole.MarkupLine($"[sandybrown]Welcome back, {currentUsername}! Here's your current profile.[/]");
            
            UserProfile currentUserProfile = new UserProfile(currentUserID, skillsList, experiencesList, certificationsList);
            currentUserProfile.GenerateProfileTable(skillsList, experiencesList, certificationsList);

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What table would you like to make changes to?")
                .PageSize(10)
                .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                .AddChoices(new[] { "Skills", "Experiences", "Certifications", "Exit" }));

            return userChoice;
        }

        public static string DataViewer()
        {
            return string.Empty;
        }
    }
}
