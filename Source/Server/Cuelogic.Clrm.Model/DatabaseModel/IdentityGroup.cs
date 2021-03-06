﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class IdentityGroup
    {
        public IdentityGroup()
        {
            Id = 0;
            GroupName = "";
            GroupDescription = "";
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            GroupRight = new List<IdentityGroupRight>();
        }
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        public List<IdentityGroupRight> GroupRight { get; set; }
        
    }
}
