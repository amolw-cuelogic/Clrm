using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using log4net;
using Cuelogic.Clrm.DataAccessLayer.Department;

namespace Cuelogic.Clrm.Repository.Department
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private readonly IMasterDepartmentDataAccess _masterDepartmentDataAccess;

        public MasterDepartmentRepository()
        {
            _masterDepartmentDataAccess = new MasterDepartmentDataAccess();
        }
        public MasterDepartment GetMasterDepartment(int MasterDepartmentId)
        {
            if (MasterDepartmentId != 0)
            {
                var MasterDepartmentDs = _masterDepartmentDataAccess.GetMasterDepartment(MasterDepartmentId);
                var MasterDepartmentObj = MasterDepartmentDs.Tables[0].ToModel<MasterDepartment>();
                return MasterDepartmentObj;
            }
            else
            {
                return new MasterDepartment();
            }
        }

        public DataSet GetMasterDepartmentList(SearchParam objSearchParam)
        {
            var ds = _masterDepartmentDataAccess.GetMasterDepartmentList(objSearchParam);
            return ds;
        }

        public void MarkMasterDepartmentInvalid(int MasterDepartmentId)
        {
            _masterDepartmentDataAccess.MarkMasterDepartmentInvalid(MasterDepartmentId);
        }

        public void SaveMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            ObjMasterDepartment.CreatedBy = userCtx.UserId;
            ObjMasterDepartment.CreatedOn = DateTime.Now.ToMySqlDateString();
            _masterDepartmentDataAccess.InsertMasterDepartment(ObjMasterDepartment);
        }

        public void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            ObjMasterDepartment.UpdatedBy = userCtx.UserId;
            ObjMasterDepartment.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterDepartmentDataAccess.UpdateMasterDepartment(ObjMasterDepartment);
        }
    }
}
