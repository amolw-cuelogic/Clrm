using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Skill
{
    public interface IMasterSkillService
    {
        string GetList(SearchParam searchParam);

        MasterSkill GetItem(int masterSkillId);

        void Save(MasterSkill masterSkill, UserContext userCtx);

        void Delete(int masterSkillId, int employeeId);
    }
}
