using Cuelogic.Clrm.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using log4net;
using Cuelogic.Clrm.DataAccessLayer.DataAccess;

namespace Cuelogic.Clrm.Repository.Repository
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private ILog applogManager = AppLogManager.GetLogger();
        private readonly IMasterDepartmentDataAccess _masterDepartmentDataAccess;

        public MasterDepartmentRepository()
        {
            _masterDepartmentDataAccess = new MasterDepartmentDataAccess();
        }
        public MasterDepartment GetMasterDepartment(int MasterDepartmentId)
        {
            try
            {
                var MasterDepartmentDs = _masterDepartmentDataAccess.GetMasterDepartment(MasterDepartmentId);
                var MasterDepartmentObj = MasterDepartmentDs.Tables[0].ToModel<MasterDepartment>();
                return MasterDepartmentObj;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public DataSet GetMasterDepartmentList(SearchParam objSearchParam)
        {
            try
            {
                var ds = _masterDepartmentDataAccess.GetMasterDepartmentList(objSearchParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void MarkMasterDepartmentInvalid(int GroupId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void SaveMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
