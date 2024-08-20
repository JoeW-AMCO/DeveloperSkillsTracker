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
                    AnsiConsole.MarkupLine("[sandybrown]Here are your skills:[/]\n");                    
                    foreach (var skill in profile.Skills)
                    {
                        AnsiConsole.MarkupLine($"[sandybrown]Skill Name:[/] {skill.Skill_Name} " + "[lightgoldenrod3]---[/]" + $"[sandybrown] Skill ID:[/] {skill.Skill_ID}");
                        AnsiConsole.MarkupLine($"[sandybrown]Skill Description:[/] {skill.Skill_Description}");
                        AnsiConsole.MarkupLine($"[lightgoldenrod3] -------------------------------- [/]");
                    }
                    var skillDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("\nWould you like to add, delete, or edit a skill?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));                   
                    return skillDecision;
                case "Experiences":
                    AnsiConsole.MarkupLine("[sandybrown]Here are your experiences:[/]\n");
                    foreach (var experience in profile.Experiences)
                    {
                        AnsiConsole.MarkupLine($"[sandybrown]Experience Name:[/] {experience.Experience_Name} " + "[lightgoldenrod3]---[/]" + $"[sandybrown] Skill ID:[/] {experience.Experience_ID}");
                        AnsiConsole.MarkupLine($"[sandybrown]Experience Description:[/] {experience.Experience_Description}");
                        AnsiConsole.MarkupLine($"[lightgoldenrod3] -------------------------------- [/]");
                    }
                    var experienceDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("\nWould you like to add, delete, or edit an experience?")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(new[] { "Add", "Delete", "Edit", "Back" }));
                    return experienceDecision;
                case "Certifications":
                    AnsiConsole.MarkupLine("[sandybrown]Here are your certifications:[/]\n");
                    foreach (var certification in profile.Certifications)
                    {
                        AnsiConsole.MarkupLine($"[sandybrown]Certification Name:[/] {certification.Certification_Name} " + "[lightgoldenrod3]---[/]" + $"[sandybrown] Certification ID:[/]  {certification.Certification_ID}");
                        AnsiConsole.MarkupLine($"[sandybrown]Certification Description:[/]  {certification.Certification_Description}");
                        AnsiConsole.MarkupLine($"[lightgoldenrod3] -------------------------------- [/]");
                    }
                    var certificationDecision = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("\nWould you like to add, delete, or edit a certification?")
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

        public static void AddMenu(MyDbContext context, UserProfile profile, string attributeChoice, string changeChoice, bool backPressed)
        {
            switch (attributeChoice) 
            {
                case "Skills":
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the name of the skill you would like to add (or enter 'back' to go back):\n[/]");                    
                    string newSkillName = Console.ReadLine() ?? string.Empty;
                    if (newSkillName.Equals("Back", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the description of the skill you would like to add:\n[/]");                    
                    string newSkillDescription = Console.ReadLine() ?? string.Empty;
                    new DimSkill(profile.UserId, newSkillName, newSkillDescription).AddUserAttribute(context);
                    break;
                case "Experiences":
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the name of the experience you would like to add (or enter 'back' to go back):\n[/]");
                    string newExperienceName = Console.ReadLine() ?? string.Empty;
                    if (newExperienceName.Equals("Back", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the description of the experience you would like to add:\n[/]");
                    string newExperienceDescription = Console.ReadLine() ?? string.Empty;
                    new DimExperience(profile.UserId, newExperienceName, newExperienceDescription).AddUserAttribute(context);
                    break;
                case "Certifications":
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the name of the certification you would like to add (or enter 'back' to go back):\n[/]");
                    string newCertificationName = Console.ReadLine() ?? string.Empty;
                    if (newCertificationName.Equals("Back", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    AnsiConsole.MarkupLine("[sandybrown]Please enter the description of the certification you would like to add:\n[/]");
                    string newCertificationDescription = Console.ReadLine() ?? string.Empty;
                    new DimCertification(profile.UserId, newCertificationName, newCertificationDescription).AddUserAttribute(context);
                    break;
                case "Back":
                    backPressed = true;
                    break;
                default:
                    Console.WriteLine("Something has gone horribly wrong.");
                    break;
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
            attributeIds.Add("Back");

            switch (attributeChoice)
            {                
                case "Skills":
                    var skillDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the skill you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (skillDeleteChoice == "Back")
                    {
                        break;
                    }
                    int skillDeleteChoiceInt = int.Parse(skillDeleteChoice);
                    DimSkill skillToDelete = context.Skills.Find(skillDeleteChoiceInt);
                    skillToDelete.DeleteUserAttribute(context);
                    break;
                case "Experiences":
                    var experienceDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the experience you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (experienceDeleteChoice == "Back")
                    {
                        break;
                    }
                    int experienceDeleteChoiceInt = int.Parse(experienceDeleteChoice);
                    DimExperience experienceToDelete = context.Experiences.Find(experienceDeleteChoiceInt);
                    experienceToDelete.DeleteUserAttribute(context);
                    break;
                case "Certifications":
                    var certificationDeleteChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the certification you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (certificationDeleteChoice == "Back")
                    {
                        break;
                    }
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
            attributeIds.Add("Back");

            switch (attributeChoice)
            {
                case "Skills":
                    var skillChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the skill you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (skillChangeChoice == "Back")
                    {
                        break;
                    }
                    int skillChangeChoiceInt = int.Parse(skillChangeChoice);
                    DimSkill skillToChange = context.Skills.Find(skillChangeChoiceInt);

                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the name of the new skill:\n[/]");                    
                    string newSkillName = Console.ReadLine() ?? string.Empty;
                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the description of the new skill:\n[/]");
                    string newSkillDescription = Console.ReadLine() ?? string.Empty;

                    DimSkill.ChangeUserAttribute(profile.UserId, skillChangeChoiceInt, newSkillName, newSkillDescription, context);
                    break;
                case "Experiences":
                    var experienceChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the experience you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (experienceChangeChoice == "Back")
                    {
                        break;
                    }
                    int experienceChangeChoiceInt = int.Parse(experienceChangeChoice);
                    DimExperience experienceToChange = context.Experiences.Find(experienceChangeChoiceInt);

                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the name of the new experience:\n[/]");
                    string newExperienceName = Console.ReadLine() ?? string.Empty;
                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the description of the new experience:\n[/]");
                    string newExperienceDescription = Console.ReadLine() ?? string.Empty;

                    DimExperience.ChangeUserAttribute(profile.UserId, experienceChangeChoiceInt, newExperienceName, newExperienceDescription, context);
                    break;
                case "Certifications":
                    var certificationChangeChoice = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[sandybrown]Please select the ID of the certification you would like to edit[/]")
                            .PageSize(10)
                            .MoreChoicesText("(↑) Move up / (↓) Move down / (Enter) Select")
                            .AddChoices(attributeIds));
                    if (certificationChangeChoice == "Back")
                    {
                        break;
                    }
                    int certificationChangeChoiceInt = int.Parse(certificationChangeChoice);
                    DimCertification certificationToChange = context.Certifications.Find(certificationChangeChoiceInt);

                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the name of the new certification:\n[/]");
                    string newCertificationName = Console.ReadLine() ?? string.Empty;
                    AnsiConsole.MarkupLine($"[sandybrown]Please enter the description of the new certification:\n[/]");
                    string newCertificationDescription = Console.ReadLine() ?? string.Empty;

                    DimCertification.ChangeUserAttribute(profile.UserId, certificationChangeChoiceInt, newCertificationName, newCertificationDescription, context);
                    break;
                default:
                    break;
            }
        }
    }
}
