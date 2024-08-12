﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperSkillsTracker
{
    internal class Experience : UserAttribute
    {
        //Constructor
        public Experience(int experienceID, int userID, string experienceName, string experienceDescription) 
            : base(experienceID, userID, experienceName, experienceDescription) { }
    }
}
