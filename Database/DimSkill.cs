﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
<<<<<<< Updated upstream
    internal class DimSkill
=======
    internal class DimSkill// : UserAttribute
>>>>>>> Stashed changes
    {
        [Key]
        public int Skill_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        [Column("Skill")]
        public string Skill_Name { get; set; }
<<<<<<< Updated upstream
=======
        [Column("Skill_Description")]
        public string Skill_Description { get; set; }        

        //Navigation property to represent the related user
        public DimUser UserPK { get; set; }

        // Parameterless constructor required by EF Core
        public DimSkill() { }

        //test constructor
        public DimSkill(int userID, string skillName, string skillDescription)
        {
            //Skill_ID = userID;            
            User_ID = userID;
            Skill_Name = skillName;
            Skill_Description = skillDescription;
        }

        public void AddUserAttribute(DimSkill newSkill)
        {
            using (var context = new MyDbContext())
            {
                context.Skills.Add(newSkill);
                context.SaveChanges();
            }
        }

        public void DeleteUserAttribute(DimSkill oldSkill)
        {
            using (var context = new MyDbContext())
            {
                context.Skills.Remove(oldSkill);
                context.SaveChanges();
            }
        }
>>>>>>> Stashed changes
    }
}
