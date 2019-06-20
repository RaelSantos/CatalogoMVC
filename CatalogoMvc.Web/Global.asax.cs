using CatalogoMvc.Data.Contexto;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CatalogoMvc.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Registrando Injeção de dependência.
            UnityConfig.RegisterComponents();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["_EntityContext"] = new CatalogoMvcContextoDados();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var contextoEntidade = HttpContext.Current.Items["_EntityContext"] as CatalogoMvcContextoDados;

            if (contextoEntidade != null)
                contextoEntidade.Dispose();                        
        }
    }
}
