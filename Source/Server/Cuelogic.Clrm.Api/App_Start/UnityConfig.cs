using Cuelogic.Clrm.Service.Interface;
using Cuelogic.Clrm.Service.Service;
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
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IMasterGroup, MasterGroupSrv>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}