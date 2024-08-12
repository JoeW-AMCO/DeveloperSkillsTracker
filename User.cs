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
        public Skill Skills { get; private set; }
        public Experience Experiences { get; private set; }
        public Certification Certifications { get; private set; }

        //Fields

        //Constructors
        public User(string name)
        {
            Username = name;
        }

        //Methods
    }
}
