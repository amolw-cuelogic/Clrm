using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.Skill
{
    public interface IMasterSkillDataAccess
    {
        DataSet GetMasterSkillList(SearchParam searchParam);

        DataSet GetMasterSkill(int masterSkillId);

        void UpdateMasterSkill(MasterSkill masterSkill);

        void InsertMasterSkill(MasterSkill masterSkill);

        void MarkMasterSkillInvalid(int masterSkillId);
    }
}
