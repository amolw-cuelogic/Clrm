﻿using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Service.Interface;
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
        IMasterDepartmentService _masterDepartmentService;
        public MasterDepartmentController(IMasterDepartmentService masterDepartmentService)
        {

            _masterDepartmentService = masterDepartmentService;
        }
        // GET: api/MasterDepartment
        public string Get(int Show, int Page, string FilterText)
        {
            var objSearchParam = new SearchParam();
            objSearchParam.FilterText = FilterText ?? "";
            objSearchParam.Page = Page;
            objSearchParam.Show = Show;
            var masterDepartmentJsonString = _masterDepartmentService.GetList(objSearchParam);
            return masterDepartmentJsonString;
        }

        // GET: api/MasterDepartment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterDepartment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MasterDepartment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterDepartment/5
        public void Delete(int id)
        {
        }
    }
}
