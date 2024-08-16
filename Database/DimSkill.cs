﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{

    internal class DimSkill : UserAttribute

    {
        [Key]
        public int Skill_ID { get; set; }
        [Column("Skill_Title")]
        public string Skill_Name { get; set; }
        [Column("Skill_Description")]
        public string Skill_Description { get; set; }        

        //Constructors
        // Parameterless constructor required by EF Core
        public DimSkill() { }
        
        public DimSkill(int userID, string skillName, string skillDescription)
            : base(userID)
        {
            Skill_Name = skillName;
            Skill_Description = skillDescription;
        }

        public override void AddUserAttribute(MyDbContext context)
        {
                context.Skills.Add(this);
                context.SaveChanges();            
        }

        public override void DeleteUserAttribute(MyDbContext context)
        {
            
        }

        public override void ChangeUserAttribute(MyDbContext context)
        {
            
        }
    }
}