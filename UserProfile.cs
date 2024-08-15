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
<<<<<<< Updated upstream
        public List<Skill> Skills { get; set; }
        public List<Certification> Certifications { get; set; }
        public List<Experience> Experiences { get; set; }
=======
        public List<DimSkill> Skills { get; set; }
        public List<DimCertification> Certifications { get; set; }
        public List<DimExperience> Experiences { get; set; }

        public UserProfile(int userId)
        {
            UserId = userId;
            Skills = new List<DimSkill>();
            Certifications = new List<DimCertification>();
            Experiences = new List<DimExperience>();
        }
>>>>>>> Stashed changes
    }
}
