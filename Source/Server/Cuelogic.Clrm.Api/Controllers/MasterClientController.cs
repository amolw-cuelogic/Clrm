using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Service.Interface;
using System;
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
            if (show < 0 || page < 0)
                throw new Exception("Negative values not allowed");
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
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var masterClient = _masterClientService.GetItem(id);
            return Ok(masterClient);
        }

        [AuthorizeUserRights(IdentityRights.MasterClient, AuthorizeFlag.Read)]
        [Route("GetCities/{id}")]
        public IHttpActionResult GetCities(int id)
        {
            if (id < 0)
                throw new Exception("Negative id now allowed");
            
            var cityList = _masterClientService.GetCityList(id);
            return Ok(cityList);
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
            if (id < 0)
                throw new Exception("Negative id now allowed");
            var userContext = base.GetUserContext();
            _masterClientService.Delete(id, userContext.UserId);
            return Ok();
        }
    }
}
