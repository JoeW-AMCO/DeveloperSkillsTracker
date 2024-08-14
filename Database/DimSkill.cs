using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimSkill
    {
        [Key]
        public int Skill_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        [Column("Skill_Title")]
        public string Skill_Name { get; set; }
        [Column("Skill_Description")]
        public string Skill_Description { get; set; }

        //Navigation property to represent the related user
        public DimUser UserPK { get; set; }
    }
}
