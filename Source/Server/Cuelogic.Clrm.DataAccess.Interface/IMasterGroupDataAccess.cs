using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterGroupDataAccess
    {
        #region GET FUNCTIONS

        DataSet GetIdentityGroupList(SearchParam searchParam);

        DataSet GetIdentityGroup(int groupId);

        DataSet GetIdentityGroupRights(int groupId);

        DataSet GetIdentityRightList();

        #endregion

        #region UPDATE FUNCTIONS

        void UpdateIdentityGroup(IdentityGroup identityGroup);

        void UpdateIdentityGroupRight(string xmlString);

        #endregion

        #region INSERT FUNCTIONS

        DataSet InsertIdentityGroup(IdentityGroup objIdentityGroup);

        void InsertIdentityGroupRight(string xmlString);

        #endregion

        #region OTHER FUNCTIONS

        void MarkGroupInvalid(int groupId, int employeeId);

        #endregion
    }
}
