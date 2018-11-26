using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.WireUp;
using DataAccess.WireUp;
using WebAPI.WireUp;
using System.Reflection;
using System.Web.Http;

namespace WebAPI.App_Start
{
    public class AutofacWebapiConfig
    {

        public static Autofac.IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, Autofac.IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static Autofac.IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterModule(new ApiMapper());
            builder.RegisterModule(new RepositoryMapper());
            builder.RegisterModule(new DatabaseMapper());

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();
            //app.UseAutofacMiddleware(Container);

            return Container;
        }

    }
}