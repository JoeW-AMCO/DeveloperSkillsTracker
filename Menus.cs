using System;
using System.Collections;
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
                AnsiConsole.Markup("\n[sandybrown]Welcome to the Developer Skills Tracker! Please enter your login details below.[/]\n\n");
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

        public static bool AddMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice, bool backPressed)
        {
            switch (attributeChoice) 
            {
                case "Skills":
                    Console.WriteLine("Please enter the name of the skill you would like to add:\n");
                    string newSkillName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the skill you would like to add:\n");
                    string newSkillDescription = Console.ReadLine() ?? string.Empty;
                    new DimSkill(profile.UserId, newSkillName, newSkillDescription).AddUserAttribute(context);
                    return backPressed;
                case "Experiences":
                    Console.WriteLine("Please enter the name of the experience you would like to add:\n");
                    string newExperienceName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the experience you would like to add:\n");
                    string newExperienceDescription = Console.ReadLine() ?? string.Empty;
                    new DimExperience(profile.UserId, newExperienceName, newExperienceDescription).AddUserAttribute(context);
                    return backPressed;
                case "Certifications":
                    Console.WriteLine("Please enter the name of the certification you would like to add:\n");
                    string newCertificationName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the certification you would like to add:\n");
                    string newCertificationDescription = Console.ReadLine() ?? string.Empty;
                    new DimCertification(profile.UserId, newCertificationName, newCertificationDescription).AddUserAttribute(context);
                    return backPressed;
                case "Back":
                    backPressed = true;
                    return backPressed;                    
                default:
                    Console.WriteLine("Something has gone horribly wrong.");
                    return backPressed;
            }
        }

        public static void DeleteMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice)
        {
            List<int> attributeIdsInt = new List<int>();
            List<string> attributeIds = new List<string>();
            if (attributeChoice == "Skills")
            {                
                attributeIdsInt = context.Skills.Where(s => s.User_ID == profile.UserId).Select(s => s.Skill_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }
            else if (attributeChoice == "Experiences")
            {
                attributeIdsInt = context.Experiences.Where(s => s.User_ID == profile.UserId).Select(e => e.Experience_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }
            else if (attributeChoice == "Certifications")
            {
                attributeIdsInt = context.Certifications.Where(s => s.User_ID == profile.UserId).Select(c => c.Certification_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }
            

            switch (attributeChoice)
            {                
                case "Skills":
                    var skillDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the skill you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int skillDeleteChoiceInt = int.Parse(skillDeleteChoice);
                    DimSkill skillToDelete = context.Skills.Find(skillDeleteChoiceInt);
                    skillToDelete.DeleteUserAttribute(context);
                    break;
                case "Experiences":
                    var experienceDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the experience you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int experienceDeleteChoiceInt = int.Parse(experienceDeleteChoice);
                    DimExperience experienceToDelete = context.Experiences.Find(experienceDeleteChoiceInt);
                    experienceToDelete.DeleteUserAttribute(context);
                    break;
                case "Certifications":
                    var certificationDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the certification you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int certificationDeleteChoiceInt = int.Parse(certificationDeleteChoice);
                    DimCertification certificationToDelete = context.Certifications.Find(certificationDeleteChoiceInt);
                    certificationToDelete.DeleteUserAttribute(context);
                    break;
                default:
                    break;
            }
        }

        public static void EditMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice)
        {
            List<int> attributeIdsInt = new List<int>();
            List<string> attributeIds = new List<string>();
            if (attributeChoice == "Skills")
            {
                attributeIdsInt = context.Skills.Where(s => s.User_ID == profile.UserId).Select(s => s.Skill_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }
            else if (attributeChoice == "Experiences")
            {
                attributeIdsInt = context.Experiences.Where(s => s.User_ID == profile.UserId).Select(e => e.Experience_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }
            else if (attributeChoice == "Certifications")
            {
                attributeIdsInt = context.Certifications.Where(s => s.User_ID == profile.UserId).Select(c => c.Certification_ID).ToList();
                attributeIds = attributeIdsInt.Select(i => i.ToString()).ToList();
            }

            switch (attributeChoice)
            {
                case "Skills":
                    var skillChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the skill you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int skillChangeChoiceInt = int.Parse(skillChangeChoice);
                    DimSkill skillToChange = context.Skills.Find(skillChangeChoiceInt);

                    Console.WriteLine("Please enter the name of the skill you would like to add:\n");
                    string newSkillName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the skill you would like to add:\n");
                    string newSkillDescription = Console.ReadLine() ?? string.Empty;

                    DimSkill.ChangeUserAttribute(profile.UserId, skillChangeChoiceInt, newSkillName, newSkillDescription, context);
                    break;
                case "Experiences":
                    var experienceChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the experience you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int experienceChangeChoiceInt = int.Parse(experienceChangeChoice);
                    DimExperience experienceToChange = context.Experiences.Find(experienceChangeChoiceInt);

                    Console.WriteLine("Please enter the name of the experience you would like to add:\n");
                    string newExperienceName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the experience you would like to add:\n");
                    string newExperienceDescription = Console.ReadLine() ?? string.Empty;

                    DimExperience.ChangeUserAttribute(profile.UserId, experienceChangeChoiceInt, newExperienceName, newExperienceDescription, context);
                    break;
                case "Certifications":
                    var certificationChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Please select the ID of the certification you would like to edit")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    int certificationChangeChoiceInt = int.Parse(certificationChangeChoice);
                    DimCertification certificationToChange = context.Certifications.Find(certificationChangeChoiceInt);

                    Console.WriteLine("Please enter the name of the certification you would like to add:\n");
                    string newCertificationName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Please enter the description of the certification you would like to add:\n");
                    string newCertificationDescription = Console.ReadLine() ?? string.Empty;

                    DimCertification.ChangeUserAttribute(profile.UserId, certificationChangeChoiceInt, newCertificationName, newCertificationDescription, context);
                    break;
                default:
                    break;
            }
        }
    }
}
