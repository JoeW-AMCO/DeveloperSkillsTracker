using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using DeveloperSkillsTracker.Database;

namespace DeveloperSkillsTracker
{
    internal abstract class UserAttribute
    {
        //Properties
        public int AttributeID { get; set; }
        public string AttributeName { get; set; }

        public string AttributeDescription { get; set; }

        //Constructors
        public UserAttribute(int attributeID, string attributeName, string attributeDescription)
        {
            AttributeID = attributeID;            
            AttributeID = attributeID;
            AttributeName = attributeName;
            AttributeDescription = attributeDescription;
        }

        //Methods
        // Abstract method to be implemented by derived classes
        public abstract void AddUserAttribute(MyDbContext context);
        public abstract void DeleteUserAttribute(MyDbContext context);
        public abstract void ChangeUserAttribute(MyDbContext context);


        //Fields to hold data
        //Properties to access data
        //Constructor to initialise data
        //Methods to manipulate data
    }
}
