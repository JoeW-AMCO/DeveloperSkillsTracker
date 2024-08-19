using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperSkillsTracker.Database;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static string TableViewer(MyDbContext context, UserProfile profile)
        {
            AnsiConsole.MarkupLine($"[sandybrown]Welcome back, {profile.Username}! Here's your current profile.[/]");

            profile.GenerateProfileTable(profile.Skills, profile.Experiences, profile.Certifications);

            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What table would you like to make changes to?")
                .PageSize(10)
                .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                .AddChoices(new[] { "Skills", "Experiences", "Certifications", "Exit" }));

            return userChoice;
        }

        public static string DataViewer(MyDbContext context, UserProfile profile, string attributeChoice)
        {
            switch (attributeChoice)
            {
                case "Skills":
                    Console.WriteLine("Here are your skills: ");
                    foreach (var skill in profile.Skills)
                    {
                        Console.WriteLine("Skill Name: " + skill.Skill_Name + " - Skill Description: " + skill.Skill_Description + " - Skill ID: " + skill.Skill_ID);
                    }
                    var skillDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Would you like to add, delete, or edit a skill?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));                   
                    return skillDecision;
                case "Experiences":
                    Console.WriteLine("Here are your experiences: ");
                    foreach (var experience in profile.Experiences)
                    {
                        Console.WriteLine("Experience Name: " + experience.Experience_Name + " - Experience Description: " + experience.Experience_Description + " - Experience ID: " + experience.Experience_ID);
                    }
                    var experienceDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Would you like to add, delete, or edit an experience?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));
                    return experienceDecision;
                case "Certifications":
                    Console.WriteLine("Here are your certifications: ");
                    foreach (var certification in profile.Certifications)
                    {
                        Console.WriteLine("Certification Name: " + certification.Certification_Name + " - Certification Description: " + certification.Certification_Description + " - Certification ID: " + certification.Certification_ID);
                    }
                    var certificationDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Would you like to add, delete, or edit a certification?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));
                    return certificationDecision;
                case "Exit":
                    Console.WriteLine("Goodbye!");
                    return "Exit";
                default:
                    return "Something has gone horribly wrong.";
            }
        }

        public static void AddMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice)
        {
            switch (attributeChoice) 
            {
                case "Skills":
                    Console.WriteLine("Please enter the name of the skill you would like to add:\n");
                    string newSkillName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the skill you would like to add:\n");
                    string newSkillDescription = Console.ReadLine() ?? string.Empty;
                    new DimSkill(profile.UserId, newSkillName, newSkillDescription).AddUserAttribute(context);
                    break;
                case "Experiences":
                    Console.WriteLine("Please enter the name of the experience you would like to add:\n");
                    string newExperienceName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the experience you would like to add:\n");
                    string newExperienceDescription = Console.ReadLine() ?? string.Empty;
                    new DimExperience(profile.UserId, newExperienceName, newExperienceDescription).AddUserAttribute(context);
                    break;
                case "Certifications":
                    Console.WriteLine("Please enter the name of the certification you would like to add:\n");
                    string newCertificationName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the certification you would like to add:\n");
                    string newCertificationDescription = Console.ReadLine() ?? string.Empty;
                    new DimCertification(profile.UserId, newCertificationName, newCertificationDescription).AddUserAttribute(context);
                    break;
                default:
                    break;
            }
        }

        public static void DeleteMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice)
        {
            switch (attributeChoice)
            {
                case "Skills":

                    break;
                case "Experiences":

                    break;
                case "Certifications":

                    break;
                default:
                    break;
            }
        }

        public static void EditMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice)
        {
            switch (attributeChoice)
            {
                case "Skills":

                    break;
                case "Experiences":

                    break;
                case "Certifications":

                    break;
                default:
                    break;
            }

            /*List<string> skillIds = new List<string>();
            foreach (var skill in skillsList)
            {
                skillIds.Add(skill.Skill_ID.ToString());
            }

            var skillAlterChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the skill you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(skillIds));
            Console.Clear();

            foreach (var skill in skillsList)
            {
                var skillIdChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Please select the ID of the skill you would like to edit")
                    .PageSize(10)
                    .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                    .AddChoices(new[] { "Skills", "Experiences", "Certifications", "Exit" }));
                Console.Clear();
            }*/
        }
    }
}
