using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Interface
{
    public interface IMasterGroupDataAccess
    {
        #region GET FUNCTIONS

        DataSet GetIdentityGroupList(SearchParam objSearchParam);

        DataSet GetIdentityGroup(int GroupId);

        DataSet GetIdentityGroupRights(int GroupId);

        DataSet GetIdentityRightList();

        #endregion

        #region UPDATE FUNCTIONS

        void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup);

        void UpdateIdentityGroupRight(string XmlString);

        #endregion

        #region UPDATE FUNCTIONS

        DataSet InsertIdentityGroup(IdentityGroup ObjIdentityGroup);

        void InsertIdentityGroupRight(string XmlString);

        #endregion

        #region OTHER FUNCTIONS

        void MarkGroupInvalid(int GroupId);

        #endregion
    }
}
