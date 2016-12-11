using System.Web.Http;

namespace ProductsApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Register Inversion of Control dependencies
            IoCConfig.RegisterDependencies();
        }
    }
}
