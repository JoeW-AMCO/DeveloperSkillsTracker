using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class Certification : UserAttribute
    {
        //Constructor
        public Certification(int userID, string certificationName, string certificationDescription)
            : base(userID, certificationName, certificationDescription) { }
    }
}
