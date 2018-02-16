using Cuelogic.Clrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using log4net;
using System.Data;

namespace Cuelogic.Clrm.Service.Service
{
    public class MasterDepartmentService : IMasterDepartmentService
    {
        private ILog applogManager = AppLogManager.GetLogger();
        private readonly IMasterDepartmentRepository _masterDepartmentRepository;
        public MasterDepartmentService(IMasterDepartmentRepository masterDepartmentRepository)
        {
            _masterDepartmentRepository = masterDepartmentRepository;
        }
        public void Delete(int DepartmentId)
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

        public MasterDepartment GetItem(int DepartmentId)
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

        public string GetList(SearchParam objSearchParam)
        {
            try
            {
                DataSet ds = _masterDepartmentRepository.GetMasterDepartmentList(objSearchParam);
                var masterDepartmentJson = ds.Tables[0].ToJsonString();
                return masterDepartmentJson;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void Save(MasterDepartment ObjMasterDepartment, UserContext userCtx)
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
