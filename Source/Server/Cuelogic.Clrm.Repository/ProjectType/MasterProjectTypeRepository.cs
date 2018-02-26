using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.ProjectType;

namespace Cuelogic.Clrm.Repository.ProjectType
{
    public class MasterProjectTypeRepository : IMasterProjectTypeRepository
    {
        private readonly IMasterProjectTypeDataAccess _masterProjectTypeDataAccess;

        public MasterProjectTypeRepository()
        {
            _masterProjectTypeDataAccess = new MasterProjectTypeDataAccess();
        }
        public void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType, UserContext userCtx)
        {
            masterProjectType.CreatedBy = userCtx.UserId;
            masterProjectType.UpdatedBy = userCtx.UserId;
            masterProjectType.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterProjectType.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterProjectTypeDataAccess.AddOrUpdateMasterProjectType(masterProjectType);
        }

        public MasterProjectType GetMasterProjectType(int masterProjectTypeId)
        {
            if (masterProjectTypeId != 0)
            {
                var ds = _masterProjectTypeDataAccess.GetMasterProjectType(masterProjectTypeId);
                var masterProjecType = ds.Tables[0].ToModel<MasterProjectType>();
                return masterProjecType;
            }
            else
            {
                return new MasterProjectType();
            }
        }

        public DataSet GetMasterProjectTypeList(SearchParam searchParam)
        {
            var ds = _masterProjectTypeDataAccess.GetMasterProjectTypeList(searchParam);
            return ds;
        }

        public void MarkMasterProjectTypeInvalid(int masterProjectTypeId)
        {
            _masterProjectTypeDataAccess.MarkMasterProjectTypeInvalid(masterProjectTypeId);
        }
    }
}
