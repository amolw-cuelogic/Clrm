using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Collections.Generic;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IUserGroupRepository
    {
        DataSet GetGroupList();
        DataSet GetEmployeeList();
        DataSet GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(string xmlString);
    }
}
