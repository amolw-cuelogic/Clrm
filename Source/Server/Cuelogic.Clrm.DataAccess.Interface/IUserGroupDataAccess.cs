using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IUserGroupDataAccess
    {
        DataSet GetGroupList();
        DataSet GetEmployeeList();
        DataSet GetIdentityGroupMembers(int gId);
        void InsertGroupUsers(string xmlString);

    }
}
