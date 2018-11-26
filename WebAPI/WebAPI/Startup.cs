using Autofac;
using Autofac.Integration.WebApi;
using BusinessLogic.WireUp;
using Common.LogUtils;
using DataAccess.WireUp;
using WebAPI.OwinUtils;
using WebAPI.WireUp;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebAPI.Startup))]
namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new CallLogger(Console.Out));
            builder.RegisterModule(new ApiMapper());
            builder.RegisterModule(new RepositoryMapper());
            builder.RegisterModule(new DatabaseMapper());

            //Set the dependency resolver to be Autofac.  
            var Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
            app.UseAutofacMiddleware(Container);

            //app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}