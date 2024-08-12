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
        public Skill(int skillID, string skillName, string skillDescription)
            : base(skillID, skillName, skillDescription) { }
    }
}
