using System.Web.Http;
using Unity;
using Unity.WebApi;
using Cuelogic.Clrm.Repository;
using System.Web.Mvc;
using Cuelogic.Clrm.Api.Controllers;
using Unity.Injection;
using Microsoft.AspNet.Identity;
using Cuelogic.Clrm.Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Cuelogic.Clrm.Service.Group;
using Cuelogic.Clrm.Service.Department;
using Cuelogic.Clrm.Service.OrganizationRole;
using Cuelogic.Clrm.Service.Skill;
using Cuelogic.Clrm.Service.Employees;

namespace Cuelogic.Clrm.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            
            container.RegisterType<IMasterGroup, MasterGroupService>();
            container.RegisterType<IMasterDepartmentService, MasterDepartmentService>();
            container.RegisterType<IMasterOrganizationRoleService, MasterOrganizationRoleService>();
            container.RegisterType<IMasterSkillService, MasterSkillService>();
            container.RegisterType<IEmployeeService, EmployeeService>();

            container.RegisterType<AccountController>(new InjectionConstructor());//needed to resolve conflict with owin injection
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}