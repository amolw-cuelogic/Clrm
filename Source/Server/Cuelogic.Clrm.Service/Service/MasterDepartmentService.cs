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
using Cuelogic.Clrm.Repository.Repository;

namespace Cuelogic.Clrm.Service.Service
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

        public MasterDepartment GetItem(int DepartmentId)
        {
            var masterDepartment = _masterDepartmentRepository.GetMasterDepartment(DepartmentId);
            return masterDepartment;

        }

        public string GetList(SearchParam objSearchParam)
        {
            DataSet ds = _masterDepartmentRepository.GetMasterDepartmentList(objSearchParam);
            var masterDepartmentJson = ds.Tables[0].ToJsonString();
            return masterDepartmentJson;

        }

        public void Save(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            if (ObjMasterDepartment.Id == 0)
                _masterDepartmentRepository.SaveMasterDepartment(ObjMasterDepartment, userCtx);
            else
                _masterDepartmentRepository.UpdateMasterDepartment(ObjMasterDepartment, userCtx);

        }
    }
}
