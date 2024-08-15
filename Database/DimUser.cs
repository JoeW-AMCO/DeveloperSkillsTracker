using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimUser
    {
        [Key]
        public int User_ID { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Password")]
        public string Password { get; set; }
<<<<<<< Updated upstream
=======

        //Navigation property to represent the collection of related skills
        public ICollection<DimSkill> SkillFK { get; set; }
        public ICollection<DimExperience> ExperienceFK { get; set; }
        public ICollection<DimCertification> CertificationFK { get; set; }

        //Constructors
        public DimUser() { }
        public DimUser(string name)
        {
            Username = name;          
        }
>>>>>>> Stashed changes
    }
}
