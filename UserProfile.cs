using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperSkillsTracker.Database;

namespace DeveloperSkillsTracker
{
    internal class UserProfile
    {
        public int UserId { get; set; }
        public List<DimSkill> Skills { get; set; }
        public List<DimCertification> Certifications { get; set; }
        public List<DimExperience> Experiences { get; set; }
    }
}
