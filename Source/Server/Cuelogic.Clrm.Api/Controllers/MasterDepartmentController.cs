using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cuelogic.Clrm.Api.Controllers
{
    public class MasterDepartmentController : ApiBaseController
    {
        private readonly IMasterDepartmentService _masterDepartmentService;
        public MasterDepartmentController(IMasterDepartmentService masterDepartmentService)
        {

            _masterDepartmentService = masterDepartmentService;
        }

        public string Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var masterDepartmentJsonString = _masterDepartmentService.GetList(objSearchParam);
            return masterDepartmentJsonString;
        }
        
        public MasterDepartment Get(int id)
        {
            var masterDepartmentObj = _masterDepartmentService.GetItem(id);
            return masterDepartmentObj;
        }
        
        public void Post([FromBody]MasterDepartment objMasterDepartment)
        {
            var userCtx = base.GetUserContext();
            _masterDepartmentService.Save(objMasterDepartment, userCtx);
        }
        
        public void Delete(int id)
        {
            _masterDepartmentService.Delete(id);
        }
    }
}
