using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterSkillRepository 
    {
        DataSet GetMasterSkillList(SearchParam searchParam);

        DataSet GetMasterSkill(int masterSkillId);

        void SaveMasterSkill(MasterSkill masterSkill);

        void UpdateMasterSkill(MasterSkill masterSkill);

        void MarkMasterSkillInvalid(int masterSkillId, int employeeId);
    }
}
