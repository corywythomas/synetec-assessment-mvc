using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Repositories;
using InterviewTestTemplatev2.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace InterviewTestTemplatev2
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<MvcInterviewV3Entities1>();
            container.RegisterType<IBonusPoolRepository, BonusPoolRepository>();
            container.RegisterType<IBonusPoolService, BonusPoolService>();
        }
    }
}