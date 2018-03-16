using System;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Repository
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private readonly IMasterDepartmentDataAccess _masterDepartmentDataAccess;

        public MasterDepartmentRepository()
        {
            var databaseType = AppUtillity.GetTargetDatabase();
            if (databaseType == DatabaseType.MySql)
                _masterDepartmentDataAccess = new MasterDepartmentDataAccessMySql();
            else
                throw new Exception(CustomError.DbConcreteImplementation);
            
        }
        public MasterDepartment GetMasterDepartment(int masterDepartmentId)
        {
            if (masterDepartmentId != 0)
            {
                var masterDepartmentDs = _masterDepartmentDataAccess.GetMasterDepartment(masterDepartmentId);
                var masterDepartment = masterDepartmentDs.Tables[0].ToModel<MasterDepartment>();
                return masterDepartment;
            }
            else
            {
                return new MasterDepartment();
            }
        }

        public DataSet GetMasterDepartmentList(SearchParam searchParam)
        {
            var ds = _masterDepartmentDataAccess.GetMasterDepartmentList(searchParam);
            return ds;
        }

        public void MarkMasterDepartmentInvalid(int masterDepartmentId, int employeeId)
        {
            _masterDepartmentDataAccess.MarkMasterDepartmentInvalid(masterDepartmentId, employeeId);
        }

        public void SaveMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx)
        {
            masterDepartment.CreatedBy = userCtx.UserId;
            masterDepartment.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterDepartmentDataAccess.InsertMasterDepartment(masterDepartment);
        }

        public void UpdateMasterDepartment(MasterDepartment masterDepartment, UserContext userCtx)
        {
            masterDepartment.UpdatedBy = userCtx.UserId;
            masterDepartment.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterDepartmentDataAccess.UpdateMasterDepartment(masterDepartment);
        }
    }
}
