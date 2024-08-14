using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class User
    {
        //Properties
        public int UserID { get; private set; }
        public string Username { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Experience> Experiences { get; private set; }
        public List<Certification> Certifications { get; private set; }

        //Fields

        //Constructors
        public User(int userID, string name)
        {
            UserID = userID;
            Username = name;            
        }

        //Methods
    }
}
