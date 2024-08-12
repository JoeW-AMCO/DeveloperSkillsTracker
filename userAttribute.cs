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
        public int AttributeID { get; set; }
        public int UserID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeDescription { get; set; }

        //Constructors
        public UserAttribute(int attributeID, int userID, string attributeName, string attributeDescription)
        {
            AttributeID = attributeID;
            UserID = userID;
            AttributeName = attributeName;
            AttributeDescription = attributeDescription;
        }

        //Methods
        public void AddUserAttribute()
        {

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
