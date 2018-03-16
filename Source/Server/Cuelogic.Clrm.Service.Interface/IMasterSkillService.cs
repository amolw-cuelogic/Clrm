using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;

namespace Cuelogic.Clrm.Service.Interface
{
    public interface IMasterSkillService
    {
        string GetList(SearchParam searchParam);

        MasterSkill GetItem(int masterSkillId);

        void Save(MasterSkill masterSkill, UserContext userCtx);

        void Delete(int masterSkillId, int employeeId);
    }
}
