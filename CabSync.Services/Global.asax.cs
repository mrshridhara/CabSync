using System.Web;
using System.Web.Http;

namespace CabSync.Services
{
    /// <summary>
    /// Represents the WebAPI application instance.
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Called to instanticate the application.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}