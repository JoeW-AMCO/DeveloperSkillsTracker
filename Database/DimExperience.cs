using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
<<<<<<< Updated upstream
    internal class DimExperience
=======
    internal class DimExperience// : UserAttribute
>>>>>>> Stashed changes
    {
        [Key]
        public int Experience_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
<<<<<<< Updated upstream
        [Column("Experience")]
        public string Skill_Name { get; set; }
=======
        [Column("Experience_Title")]
        public string Experience_Name { get; set; }
        [Column("Experience_Description")]
        public string Experience_Description { get; set; }

        //Navigation property to represent the the related user
        public DimUser UserPK { get; set; }

        // Parameterless constructor required by EF Core
        public DimExperience() { }

        //test constructor
        public DimExperience(int userID, string experienceName, string experienceDescription)
        {
            //Skill_ID = userID;            
            User_ID = userID;
            Experience_Name = experienceName;
            Experience_Description = experienceDescription;
        }

        public void AddUserAttribute(DimExperience newExperience)
        {
            using (var context = new MyDbContext())
            {
                context.Experiences.Add(newExperience);
                context.SaveChanges();
            }
        }

        public void DeleteUserAttribute(DimExperience oldExperience)
        {
            using (var context = new MyDbContext())
            {
                context.Experiences.Remove(oldExperience);
                context.SaveChanges();
            }
        }
>>>>>>> Stashed changes
    }
}
