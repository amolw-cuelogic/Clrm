using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Cuelogic.Clrm.Api.Filter.CustomFilter;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.Api.Controllers
{
    [RoutePrefix("api/Client")]
    public class MasterClientController : ApiBaseController
    {
        private readonly IMasterClientService _masterClientService;
        public MasterClientController(IMasterClientService masterClientService)
        {
            _masterClientService = masterClientService;
        }

        [AuthorizeUserRights(IdentityRights.MasterClient, AuthorizeFlag.Read)]
        [Route("")]
        public IHttpActionResult Get(int show, int page, string filterText)
        {
            var searchParam = new SearchParam();
            searchParam.FilterText = filterText ?? "";
            searchParam.Page = page;
            searchParam.Show = show;
            var jsonString = _masterClientService.GetList(searchParam);
            return Ok(jsonString);
        }

        [AuthorizeUserRights(IdentityRights.MasterClient, AuthorizeFlag.Read)]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var masterClient = _masterClientService.GetItem(id);
            return Ok(masterClient);
        }

        [AuthorizeUserRights(IdentityRights.MasterClient, AuthorizeFlag.Write)]
        [Route("")]
        public IHttpActionResult Post([FromBody]MasterClient masterClient)
        {
            var userCtx = base.GetUserContext();
            _masterClientService.Save(masterClient, userCtx);
            return Ok();
        }

        [AuthorizeUserRights(IdentityRights.MasterClient, AuthorizeFlag.Delete)]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _masterClientService.Delete(id);
            return Ok();
        }
    }
}
