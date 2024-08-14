using DeveloperSkillsTracker.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class UserAttribute
    {
        //Properties
        public int UserID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }

        //Constructors
        public UserAttribute(int userID, string attributeName, string attributeDescription)
        {
            UserID = userID;            
            AttributeName = attributeName;
            AttributeDescription = attributeDescription;
        }

        //Methods
        public void AddUserAttribute(int userId, string attributeName, string attributeDesc)
        {
            using (var context = new MyDbContext())
            {
                var newSkill = new DimSkill
                {
                    User_ID = userId,
                    Skill_Name = attributeName,
                    Skill_Description = attributeDesc
                };

                context.Skills.Add(newSkill);
                context.SaveChanges();
            }
        }

        public void UpdateUserAttribute()
        {

        }

        public void DeleteUserAttribute() 
        {

        }



        //Fields to hold data
        //Properties to access data
        //Constructor to initialise data
        //Methods to manipulate data
    }
}
