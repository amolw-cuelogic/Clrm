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
        DataSet GetMasterSkillList(SearchParam objSearchParam);

        DataSet GetMasterSkill(int MasterSkillId);

        void UpdateMasterSkill(MasterSkill ObjMasterSkill);

        void InsertMasterSkill(MasterSkill ObjMasterSkill);

        void MarkMasterSkillInvalid(int MasterSkillId);
    }
}
