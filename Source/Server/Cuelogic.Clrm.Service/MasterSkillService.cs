using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;
using System;

namespace Cuelogic.Clrm.Service
{
    public class MasterSkillService : IMasterSkillService
    {
        private readonly IMasterSkillRepository _masterSkillRepository;

        public MasterSkillService()
        {
            _masterSkillRepository = new MasterSkillRepository();
        }
        public void Delete(int masterSkillId, int employeeId)
        {
            _masterSkillRepository.MarkMasterSkillInvalid(masterSkillId, employeeId);
        }

        public MasterSkill GetItem(int masterSkillId)
        {

            if (masterSkillId != 0)
            {
                var masterSkillDs = _masterSkillRepository.GetMasterSkill(masterSkillId);
                var masterSkill = masterSkillDs.Tables[0].ToModel<MasterSkill>();
                return masterSkill;
            }
            else
            {
                return new MasterSkill();
            }
        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _masterSkillRepository.GetMasterSkillList(searchParam);
            var masterSkillJson = ds.Tables[0].ToJsonString();
            return masterSkillJson;
        }

        public void Save(MasterSkill masterSkill, UserContext userCtx)
        {
            if (masterSkill.Id == 0)
            {
                masterSkill.CreatedBy = userCtx.UserId;
                masterSkill.CreatedOn = DateTime.Now.ToMySqlDateString();
                _masterSkillRepository.SaveMasterSkill(masterSkill);
            }
            else
            {
                masterSkill.UpdatedBy = userCtx.UserId;
                masterSkill.UpdatedOn = DateTime.Now.ToMySqlDateString();
                _masterSkillRepository.UpdateMasterSkill(masterSkill);
            }
        }
    }
}
