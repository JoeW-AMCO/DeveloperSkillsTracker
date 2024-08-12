using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class UserProfile
    {
        public int UserId { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
