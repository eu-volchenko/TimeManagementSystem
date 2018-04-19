﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeManagementSystem.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string InitialEffort { get; set; }
        public string InitialMilestones { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InitialTimeLine { get; set; }
    }
}