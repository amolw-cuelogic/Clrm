using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.Skill;

namespace Cuelogic.Clrm.Repository.Skill
{
    public class MasterSkillRepository : IMasterSkillRepository
    {
        private readonly IMasterSkillDataAccess _masterSkillDataAccess;
        public MasterSkillRepository()
        {
            _masterSkillDataAccess = new MasterSkillDataAccess();
        }
        public MasterSkill GetMasterSkill(int masterSkillId)
        {
            if (masterSkillId != 0)
            {
                var masterSkillDs = _masterSkillDataAccess.GetMasterSkill(masterSkillId);
                var masterSkill = masterSkillDs.Tables[0].ToModel<MasterSkill>();
                return masterSkill;
            }
            else
            {
                return new MasterSkill();
            }
        }

        public DataSet GetMasterSkillList(SearchParam searchParam)
        {
            var ds = _masterSkillDataAccess.GetMasterSkillList(searchParam);
            return ds;
        }

        public void MarkMasterSkillInvalid(int masterSkillId, int employeeId)
        {
            _masterSkillDataAccess.MarkMasterSkillInvalid(masterSkillId, employeeId);
        }

        public void SaveMasterSkill(MasterSkill masterSkill, UserContext userCtx)
        {
            masterSkill.CreatedBy = userCtx.UserId;
            masterSkill.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterSkillDataAccess.InsertMasterSkill(masterSkill);
        }

        public void UpdateMasterSkill(MasterSkill masterSkill, UserContext userCtx)
        {
            masterSkill.UpdatedBy = userCtx.UserId;
            masterSkill.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterSkillDataAccess.UpdateMasterSkill(masterSkill);
        }
    }
}
