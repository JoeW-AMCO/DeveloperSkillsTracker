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
        public Skill(int skillID, int userID, string skillName, string skillDescription)
            : base(skillID, userID, skillName, skillDescription) { }
    }
}
