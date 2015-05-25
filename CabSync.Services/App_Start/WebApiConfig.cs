using System.Web.Http;

namespace CabSync.Services
{
    /// <summary>
    /// Contains the WebAPI configuration.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the routes for WebAPI.
        /// </summary>
        /// <param name="config">The HTTP configuration instance.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}