using DeveloperSkillsTracker.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class UserAttribute
    {
        //Properties
        /*public int UserID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }*/
        public int Skill_ID { get; set; }
        public int User_ID { get; set; }
        public string Skill_Name { get; set; }

        public string Skill_Description { get; set; }

        //Constructors
        /*public UserAttribute(int userID, string attributeName, string attributeDescription)
        {
            //Skill_ID = userID;            
            User_ID = userID;
            Skill_Name = attributeName;
            Skill_Description = attributeDescription;
        }*/

        //Methods
        public virtual void AddUserAttribute(DimSkill newSkill)
        {
        }

        public virtual void AddUserAttribute(DimExperience newExperience)
        {
        }

        public virtual void AddUserAttribute(DimCertification tempCertification)
        {
        }

        public virtual void UpdateUserAttribute()
        {
        }

        public virtual void DeleteUserAttribute(int userID, string attributeName) 
        {         
        }



        //Fields to hold data
        //Properties to access data
        //Constructor to initialise data
        //Methods to manipulate data
    }
}
