﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class MasterProjectRole
    {
        public MasterProjectRole()
        {
            Id = 0;
            Role = "";
            Costing = 0;
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
        }
        public int Id { get; set; }
        public string Role { get; set; }
        public int Costing { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
    }
}