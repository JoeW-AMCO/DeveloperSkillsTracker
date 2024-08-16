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
        [Column("Certification_Title")]
        public string Certification_Name { get; set; }
        [Column("Certification_Description")]
        public string Certification_Description { get; set; }

        //Constructors
        // Parameterless constructor required by EF Core
        public DimCertification() { }

        public DimCertification(int userID, string certificationName, string certificationDescription)
            : base(userID)
        {
            Certification_Name = certificationName;
            Certification_Description = certificationDescription;
        }

        public override void AddUserAttribute(MyDbContext context)
        {
            context.Certifications.Add(this);
            context.SaveChanges();
        }

        public override void DeleteUserAttribute(MyDbContext context)
        {
            context.Certifications.Remove(this);
            context.SaveChanges();
        }

        public static void ChangeUserAttribute(int currentUserID, int certificationID, string certificationName, string certificationDescription, MyDbContext context)
        {
            var updatedCertification = context.Certifications.FirstOrDefault(x => x.Certification_ID == certificationID);
            int updatedCertificationID = updatedCertification.User_ID;
            if (updatedCertification != null && updatedCertificationID == currentUserID)
            {
                updatedCertification.Certification_Name = certificationName;
                updatedCertification.Certification_Description = certificationDescription;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Couldn't save changes.");
            }
        }
    }
}