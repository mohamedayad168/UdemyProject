﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Service.DataTransferObjects.Create
{
    public class CourseRequirementCTO
    {
        public string Requirement { get; set; } = string.Empty;
        public int CourseId { get; set; }
    }
}
