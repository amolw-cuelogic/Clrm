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
            #region IdentityGroup | IdentityGroupRight 

            public const string spGetIdentityGroupList = "spGetIdentityGroupList";
            public const string spGetIdentityGroup = "spGetIdentityGroup";
            public const string spGetIdentityGroupRights = "spGetIdentityGroupRights";
            public const string spUpdateIdentityGroup = "spUpdateIdentityGroup";
            public const string spBulkUpdateIdentityGroupRight = "spBulkUpdateIdentityGroupRight";
            public const string spInsertIdentityGroup = "spInsertIdentityGroup";
            public const string spBulkInsertIdentityGroupRight = "spBulkInsertIdentityGroupRight";
            public const string spIdentityGroupMarkInvalid = "spIdentityGroupMarkInvalid";
            public const string spGetIdentityRight = "spGetIdentityRight";

            #endregion

            #region Employee 

            public const string spGetEmployeeByEmailId = "spGetEmployeeByEmailId";

            #endregion
        }
    }
}
