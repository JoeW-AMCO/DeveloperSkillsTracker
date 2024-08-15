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
        public string AttributeName { get; set; }
<<<<<<< Updated upstream
        public string AttributeDescription { get; set; }
=======
        public string AttributeDescription { get; set; }*/
        public int Attribute_ID { get; set; }
        public int User_ID { get; set; }
        public string Attribute_Name { get; set; }

        public string Attribute_Description { get; set; }
>>>>>>> Stashed changes

        //Constructors
        public UserAttribute(int attributeID, string attributeName, string attributeDescription)
        {
            AttributeID = attributeID;            
            AttributeName = attributeName;
            AttributeDescription = attributeDescription;
        }

        //Methods
<<<<<<< Updated upstream
        public void AddUserAttribute()
        {

=======
        public virtual void AddUserAttribute(DimSkill newSkill)
        {            
>>>>>>> Stashed changes
        }

        public void UpdateUserAttribute()
        {

        }

        public void DeleteUserAttribute() 
        {

<<<<<<< Updated upstream
=======
        public virtual void UpdateUserAttribute()
        {
        }

        public virtual void DeleteUserAttribute(DimSkill oldSkill)
        {         
>>>>>>> Stashed changes
        }

        public virtual void DeleteUserAttribute(DimExperience oldExperience)
        {
        }

        public virtual void DeleteUserAttribute(DimCertification oldCertification)
        {
        }



        //Fields to hold data
        //Properties to access data
        //Constructor to initialise data
        //Methods to manipulate data
    }
}
