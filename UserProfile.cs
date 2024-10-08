﻿using DeveloperSkillsTracker.Database;
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
        public string Username { get; set; }
        public int UserId { get; set; }


        public List<DimSkill> Skills { get; set; }
        public List<DimCertification> Certifications { get; set; }
        public List<DimExperience> Experiences { get; set; }

        public UserProfile(string username, int userId, List<DimSkill> skills, List<DimExperience> experiences, List<DimCertification> certifications)
        {
            Username = username;
            UserId = userId;
            Skills = skills;
            Experiences = experiences;
            Certifications = certifications;
        }

        public UserProfile(string username, int userId)
        {
            Username = username;
            UserId = userId;
            Skills = new List<DimSkill>();
            Experiences = new List<DimExperience>();
            Certifications = new List<DimCertification>();
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
    }
}