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
    public class MasterProjectTypeRepository : IMasterProjectTypeRepository
    {
        private readonly IMasterProjectTypeDataAccess _masterProjectTypeDataAccess;

        public MasterProjectTypeRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterProjectTypeDataAccess = new MasterProjectTypeDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
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

        public DataSet GetMasterProjectTypeValidList()
        {
            var ds = _masterProjectTypeDataAccess.GetMasterProjectTypeValidList();
            return ds;
        }

        public void MarkMasterProjectTypeInvalid(int masterProjectTypeId, int employeeId)
        {
            _masterProjectTypeDataAccess.MarkMasterProjectTypeInvalid(masterProjectTypeId, employeeId);
        }
    }
}
