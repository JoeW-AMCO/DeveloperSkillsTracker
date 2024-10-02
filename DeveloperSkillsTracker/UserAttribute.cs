using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using DeveloperSkillsTracker.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker
{
    internal abstract class UserAttribute
    {
        //Properties
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        //Navigation property to represent the related user
        public DimUser UserPK { get; set; }

        //Constructors
        protected UserAttribute() { }

        protected UserAttribute(int userID)
        {
            User_ID = userID;            
        }

        //Methods
        // Abstract method to be implemented by derived classes
        public abstract void AddUserAttribute(MyDbContext context);
        public abstract void DeleteUserAttribute(MyDbContext context);
        //public abstract void ChangeUserAttribute(MyDbContext context);
    }
}
