using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IMasterSkillDataAccess
    {
        DataSet GetMasterSkillList(SearchParam searchParam);

        DataSet GetMasterSkill(int masterSkillId);

        void UpdateMasterSkill(MasterSkill masterSkill);

        void InsertMasterSkill(MasterSkill masterSkill);

        void MarkMasterSkillInvalid(int masterSkillId, int employeeId);
    }
}
