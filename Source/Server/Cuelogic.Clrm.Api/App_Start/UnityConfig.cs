using Cuelogic.Clrm.Service;
using Cuelogic.Clrm.Service.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Cuelogic.Clrm.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IMasterGroupService, MasterGroupService>();
            container.RegisterType<IMasterDepartmentService, MasterDepartmentService>();
            container.RegisterType<IMasterOrganizationRoleService, MasterOrganizationRoleService>();
            container.RegisterType<IMasterSkillService, MasterSkillService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IMasterRoleService, MasterRoleService>();
            container.RegisterType<IMasterProjectTypeService, MasterProjectTypeService>();
            container.RegisterType<IMasterClientService, MasterClientService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IAllocationService, AllocationService>();
            container.RegisterType<ICommonService, CommonService>();
            container.RegisterType<IUserGroupService, UserGroupService>();

            //container.RegisterType<AccountController>(new InjectionConstructor());//needed to resolve conflict with owin injection
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}