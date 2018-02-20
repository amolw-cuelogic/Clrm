using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using log4net;
using System.Data;
using Cuelogic.Clrm.Repository.Department;

namespace Cuelogic.Clrm.Service.Department
{
    public class MasterDepartmentService : IMasterDepartmentService
    {
        private readonly IMasterDepartmentRepository _masterDepartmentRepository;
        public MasterDepartmentService()
        {
            _masterDepartmentRepository = new MasterDepartmentRepository();
        }
        public void Delete(int DepartmentId)
        {
            _masterDepartmentRepository.MarkMasterDepartmentInvalid(DepartmentId);

        }

        public MasterDepartment GetItem(int departmentId)
        {
            var masterDepartment = _masterDepartmentRepository.GetMasterDepartment(departmentId);
            return masterDepartment;

        }

        public string GetList(SearchParam searchParam)
        {
            DataSet ds = _masterDepartmentRepository.GetMasterDepartmentList(searchParam);
            var masterDepartmentJson = ds.Tables[0].ToJsonString();
            return masterDepartmentJson;

        }

        public void Save(MasterDepartment masterDepartment, UserContext userCtx)
        {
            if (masterDepartment.Id == 0)
                _masterDepartmentRepository.SaveMasterDepartment(masterDepartment, userCtx);
            else
                _masterDepartmentRepository.UpdateMasterDepartment(masterDepartment, userCtx);

        }
    }
}
