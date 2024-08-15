using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimCertification : UserAttribute
    {
        [Key]
        public int Certification_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        [Column("Certification_Title")]
        public string Certification_Name { get; set; }
        [Column("Certification_Description")]
        public string Certification_Description { get; set; }

        //Navigation property to represent the related user
        public DimUser UserPK { get; set; }

        // Parameterless constructor required by EF Core
        public DimCertification() { }

        //test constructor
        public DimCertification(int userID, string certificationName, string certificationDescription)
        {
            //Skill_ID = userID;            
            User_ID = userID;
            Skill_Name = certificationName;
            Skill_Description = certificationDescription;
        }

        public override void AddUserAttribute(DimCertification newCertification)
        {
            using (var context = new MyDbContext())
            {
                context.Certifications.Add(newCertification);
                context.SaveChanges();
            }
        }
    }
}
