using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebEstacionamentoTcc20.Classes;
using WebEstacionamentoTcc20.Mappers;

namespace WebEstacionamentoTcc20
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.ControleContext, Migrations.Configuration>());
            this.CheckRoles();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMappings();
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin")); System.Data.Entity.SqlServer.SqlProviderServices.SqlServerTypesAssemblyName = "Microsoft.SqlServer.Types, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91";
        }

        private void CheckRoles()
        {
            Utilidades.CheckRole("Admin");
            Utilidades.CheckRole("UsuarioEst");
            Utilidades.CheckRole("UsuarioApp");
        }
    }
}
