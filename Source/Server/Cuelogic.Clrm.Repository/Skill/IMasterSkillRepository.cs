using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Skill
{
    public interface IMasterSkillRepository 
    {
        DataSet GetMasterSkillList(SearchParam objSearchParam);

        MasterSkill GetMasterSkill(int MasterSkillId);

        void SaveMasterSkill(MasterSkill ObjMasterSkill, UserContext userCtx);

        void UpdateMasterSkill(MasterSkill ObjMasterSkill, UserContext userCtx);

        void MarkMasterSkillInvalid(int MasterSkillId);
    }
}
