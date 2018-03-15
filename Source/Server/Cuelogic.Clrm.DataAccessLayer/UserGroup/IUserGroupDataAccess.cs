using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.UserGroup
{
    public interface IUserGroupDataAccess
    {
        DataSet GetGroupList();
        DataSet GetEmployeeList();
        DataSet GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(string xmlString);

    }
}
