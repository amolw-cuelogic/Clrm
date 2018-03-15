using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Skill;
using System.Data;

namespace Cuelogic.Clrm.Service.Skill
{
    public class MasterSkillService : IMasterSkillService
    {
        private readonly IMasterSkillRepository _IMasterSkillRepository;

        public MasterSkillService()
        {
            _IMasterSkillRepository = new MasterSkillRepository();
        }
        public void Delete(int masterSkillId, int employeeId)
        {
            _IMasterSkillRepository.MarkMasterSkillInvalid(masterSkillId, employeeId);
        }

        public MasterSkill GetItem(int masterSkillId)
        {
            var masterSkill = _IMasterSkillRepository.GetMasterSkill(masterSkillId);
            return masterSkill;
        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _IMasterSkillRepository.GetMasterSkillList(searchParam);
            var masterSkillJson = ds.Tables[0].ToJsonString();
            return masterSkillJson;
        }

        public void Save(MasterSkill masterSkill, UserContext userCtx)
        {
            if (masterSkill.Id == 0)
                _IMasterSkillRepository.SaveMasterSkill(masterSkill, userCtx);
            else
                _IMasterSkillRepository.UpdateMasterSkill(masterSkill, userCtx);
        }
    }
}
