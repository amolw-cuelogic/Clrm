using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class Allocation
    {
        public Allocation()
        {
            Id = 0;
            EmployeeId = 0;
            ProjectRoleId = 0;
            ProjectId = 0;
            IsBillable = false;
            PercentageAllocation = 0;
            StartDate = "";
            EndDate = "";
            IsValid = false;
            CreatedBy = 0;
            CreatedOn = "";
            UpdatedBy = 0;
            UpdatedOn = "";
            CreatedByName = "";
            UpdatedByName = "";
            ExistingAllocation = 0;
            SelectListEmployee = new List<Employee>();
            SelectListMasterRole = new List<MasterRole>();
            SelectListProject = new List<Project>();

        }
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectRoleId { get; set; }
        public int ProjectId { get; set; }
        public bool IsBillable { get; set; }
        public int PercentageAllocation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }

        #region METADATA
        public Decimal ExistingAllocation { get; set; }
        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }
        public List<Employee> SelectListEmployee { get; set;}
        public List<MasterRole> SelectListMasterRole { get; set; }
        public List<Project> SelectListProject { get; set; }

        #endregion
    }
}
