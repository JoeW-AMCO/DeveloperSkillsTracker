using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperSkillsTracker.Database
{
    internal class DimExperience
    {
        [Key]
        public int Experience_ID { get; set; }
        [Column("FK_User_ID")]
        public int User_ID { get; set; }
        [Column("Experience_Title")]
        public string Experience_Name { get; set; }
        [Column("Experience_Description")]
        public string Experience_Description { get; set; }
    }
}
