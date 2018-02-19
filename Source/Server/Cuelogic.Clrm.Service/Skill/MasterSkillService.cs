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
        public void Delete(int MasterSkillId)
        {
            _IMasterSkillRepository.MarkMasterSkillInvalid(MasterSkillId);
        }

        public MasterSkill GetItem(int MasterSkillId)
        {
            var masterSkill = _IMasterSkillRepository.GetMasterSkill(MasterSkillId);
            return masterSkill;
        }

        public string GetList(SearchParam objSearchParam)
        {
            DataSet ds = _IMasterSkillRepository.GetMasterSkillList(objSearchParam);
            var masterSkillJson = ds.Tables[0].ToJsonString();
            return masterSkillJson;
        }

        public void Save(MasterSkill ObjMasterSkill, UserContext userCtx)
        {
            if (ObjMasterSkill.Id == 0)
                _IMasterSkillRepository.SaveMasterSkill(ObjMasterSkill, userCtx);
            else
                _IMasterSkillRepository.UpdateMasterSkill(ObjMasterSkill, userCtx);
        }
    }
}
