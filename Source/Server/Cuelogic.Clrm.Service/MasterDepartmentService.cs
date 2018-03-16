using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Service.Interface;

namespace Cuelogic.Clrm.Service
{
    public class MasterDepartmentService : IMasterDepartmentService
    {
        private readonly IMasterDepartmentRepository _masterDepartmentRepository;
        public MasterDepartmentService()
        {
            _masterDepartmentRepository = new MasterDepartmentRepository();
        }
        public void Delete(int DepartmentId, int employeeId)
        {
            _masterDepartmentRepository.MarkMasterDepartmentInvalid(DepartmentId, employeeId);

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
