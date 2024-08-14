using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class Skill : UserAttribute
    {
        //Constructor
        public Skill(int userID, string skillName, string skillDescription)
            : base(userID, skillName, skillDescription) { }
    }
}
