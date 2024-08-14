using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimCertification
    {
        [Key]
        public int Certification_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        [Column("Certification_Title")]
        public string Certification_Name { get; set; }
        [Column("Certification_Description")]
        public string Certification_Description { get; set; }
    }
}
