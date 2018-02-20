using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class AppConstants
    {
        public static class StoreProcedure
        {
            #region MASTER GROUP 

            public const string spIdentityGroup_GetList = "spIdentityGroup_GetList";
            public const string spIdentityGroup_Get = "spIdentityGroup_Get";
            public const string spIdentityGroupRight_Get = "spIdentityGroupRight_Get";
            public const string spIdentityGroup_Update = "spIdentityGroup_Update";
            public const string spIdentityGroupRight_BulkUpdate = "spIdentityGroupRight_BulkUpdate";
            public const string spIdentityGroup_Insert = "spIdentityGroup_Insert";
            public const string spIdentityGroupRight_BulkInsert = "spIdentityGroupRight_BulkInsert";
            public const string spIdentityGroup_MarkInvalid = "spIdentityGroup_MarkInvalid";
            public const string spIdentityRight_Get = "spIdentityRight_Get";

            #endregion

            #region COMMON 

            public const string spEmployee_GetByEmailId = "spEmployee_GetByEmailId";

            #endregion

            #region MASTER DEPARTMENT 

            public const string spMasterDepartment_GetList = "spMasterDepartment_GetList";
            public const string spMasterDepartment_Get = "spMasterDepartment_Get";
            public const string spMasterDepartment_MarkInvalid = "spMasterDepartment_MarkInvalid";
            public const string spMasterDepartment_Update = "spMasterDepartment_Update";
            public const string spMasterDepartment_Insert = "spMasterDepartment_Insert";

            #endregion

            #region MASTER ORGANIZATION ROLE

            public const string spMasterOrganizationRole_GetList = "spMasterOrganizationRole_GetList";
            public const string spMasterOrganizationRole_Get = "spMasterOrganizationRole_Get";
            public const string spMasterOrganizationRole_Insert = "spMasterOrganizationRole_Insert";
            public const string spMasterOrganizationRole_Update = "spMasterOrganizationRole_Update";
            public const string spMasterOrganizationRole_MarkInvalid = "spMasterOrganizationRole_MarkInvalid";

            #endregion

            #region MASTER SKILLS

            public const string spMasterSkill_Get = "spMasterSkill_Get";
            public const string spMasterSkill_GetList = "spMasterSkill_GetList";
            public const string spMasterSkill_Insert = "spMasterSkill_Insert";
            public const string spMasterSkill_MarkInvalid = "spMasterSkill_MarkInvalid";
            public const string spMasterSkill_Update = "spMasterSkill_Update";

            #endregion
        }
    }
}
