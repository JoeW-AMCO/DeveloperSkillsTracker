using DeveloperSkillsTracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeveloperSkillsTracker
{
    internal class UserProfile
    {
        public int UserId { get; set; }


        public List<DimSkill> Skills { get; set; }
        public List<DimCertification> Certifications { get; set; }
        public List<DimExperience> Experiences { get; set; }

        public UserProfile(int userId, List<DimSkill> skills, List<DimExperience> experiences, List<DimCertification> certifications)
        {
            UserId = userId;
            Skills = skills;
            Experiences = experiences;
            Certifications = certifications;
        }



        public void GenerateProfileTable(List<DimSkill> skillsList, List<DimExperience> experiencesList, List<DimCertification> certificationsList)
        {
            var skillsTable = new Spectre.Console.Table();
            var experiencesTable = new Spectre.Console.Table();
            var certificationsTable = new Spectre.Console.Table();
            skillsTable.Title("[bold]Skills[/]");
            experiencesTable.Title("[bold]Experiences[/]");
            certificationsTable.Title("[bold]Certifications[/]");


            skillsTable.AddColumn("[bold]Name[/]").Centered();
            skillsTable.AddColumn("[bold]Description[/]").Centered();

            experiencesTable.AddColumn("[bold]Name[/]").Centered();
            experiencesTable.AddColumn("[bold]Description[/]").Centered();

            certificationsTable.AddColumn("[bold]Name[/]").Centered();
            certificationsTable.AddColumn("[bold]Description[/]").Centered();

            foreach (var skill in skillsList)
            {
                skillsTable.AddRow(skill.Skill_Name, skill.Skill_Description);
            }
            foreach (var experience in experiencesList)
            {
                experiencesTable.AddRow(experience.Experience_Name, experience.Experience_Description);
            }
            foreach (var certification in certificationsList)
            {
                certificationsTable.AddRow(certification.Certification_Name, certification.Certification_Description);
            }

            AnsiConsole.Write(skillsTable);
            AnsiConsole.Write(experiencesTable);
            AnsiConsole.Write(certificationsTable);
        }
        
        public static void AlterMenu(List<DimSkill> skillsList) 
        {
            List<string> skillIds = new List<string>();
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
            }
        }

        public static void AlterMenu(List<DimExperience> experiencesList)
        {

        }

        public static void AlterMenu(List<DimCertification> certificationsList)
        {

        }
    }
}