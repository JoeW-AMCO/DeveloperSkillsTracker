using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimExperience : UserAttribute
    {
        [Key]
        public int Experience_ID { get; set; }
        [Column("Experience_Title")]
        public string Experience_Name { get; set; }
        [Column("Experience_Description")]
        public string Experience_Description { get; set; }

        //Constructors
        // Parameterless constructor required by EF Core
        public DimExperience() { }

        public DimExperience(int userID, string experienceName, string experienceDescription)
            : base(userID)
        {
            Experience_Name = experienceName;
            Experience_Description = experienceDescription;
        }

        public override void AddUserAttribute(MyDbContext context)
        {
            context.Experiences.Add(this);
            context.SaveChanges();
        }

        public override void DeleteUserAttribute(MyDbContext context)
        {
            context.Experiences.Remove(this);
            context.SaveChanges();
        }

        public static void ChangeUserAttribute(int currentUserID, int experienceID, string experienceName, string experienceDescription, MyDbContext context)
        {
            var updatedExperience = context.Experiences.FirstOrDefault(x => x.Experience_ID == experienceID);
            int updatedExperienceID = updatedExperience.User_ID;
            if (updatedExperience != null && updatedExperienceID == currentUserID)
            {
                updatedExperience.Experience_Name = experienceName;
                updatedExperience.Experience_Description = experienceDescription;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Couldn't save changes.");
            }
        }
    }
}