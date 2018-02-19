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
        public MasterSkill GetMasterSkill(int MasterSkillId)
        {
            if (MasterSkillId != 0)
            {
                var MasterSkillDs = _masterSkillDataAccess.GetMasterSkill(MasterSkillId);
                var MasterSkillObj = MasterSkillDs.Tables[0].ToModel<MasterSkill>();
                return MasterSkillObj;
            }
            else
            {
                return new MasterSkill();
            }
        }

        public DataSet GetMasterSkillList(SearchParam objSearchParam)
        {
            var ds = _masterSkillDataAccess.GetMasterSkillList(objSearchParam);
            return ds;
        }

        public void MarkMasterSkillInvalid(int MasterSkillId)
        {
            _masterSkillDataAccess.MarkMasterSkillInvalid(MasterSkillId);
        }

        public void SaveMasterSkill(MasterSkill ObjMasterSkill, UserContext userCtx)
        {
            ObjMasterSkill.CreatedBy = userCtx.UserId;
            ObjMasterSkill.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterSkillDataAccess.InsertMasterSkill(ObjMasterSkill);
        }

        public void UpdateMasterSkill(MasterSkill ObjMasterSkill, UserContext userCtx)
        {
            ObjMasterSkill.UpdatedBy = userCtx.UserId;
            ObjMasterSkill.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterSkillDataAccess.UpdateMasterSkill(ObjMasterSkill);
        }
    }
}
