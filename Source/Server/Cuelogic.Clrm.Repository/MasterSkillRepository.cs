using System;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class MasterSkillRepository : IMasterSkillRepository
    {
        private readonly IMasterSkillDataAccess _masterSkillDataAccess;
        public MasterSkillRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterSkillDataAccess = new MasterSkillDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
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
