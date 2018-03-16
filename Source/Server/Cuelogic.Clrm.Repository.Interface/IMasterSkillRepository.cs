using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterSkillRepository 
    {
        DataSet GetMasterSkillList(SearchParam searchParam);

        MasterSkill GetMasterSkill(int masterSkillId);

        void SaveMasterSkill(MasterSkill masterSkill, UserContext userCtx);

        void UpdateMasterSkill(MasterSkill masterSkill, UserContext userCtx);

        void MarkMasterSkillInvalid(int masterSkillId, int employeeId);
    }
}
