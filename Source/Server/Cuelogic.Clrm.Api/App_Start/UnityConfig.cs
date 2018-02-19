using Cuelogic.Clrm.Service.Interface;
using Cuelogic.Clrm.Service.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository;
using System.Web.Mvc;
using Cuelogic.Clrm.Api.Controllers;
using Unity.Injection;
using Microsoft.AspNet.Identity;
using Cuelogic.Clrm.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cuelogic.Clrm.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            
            container.RegisterType<IMasterGroup, MasterGroupService>();
            container.RegisterType<IMasterDepartmentService, MasterDepartmentService>();

            container.RegisterType<AccountController>(new InjectionConstructor());//needed to resolve conflict with owin injection
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}