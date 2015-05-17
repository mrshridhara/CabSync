using System.Web.Http;

namespace CabSync.Services.Controllers
{
    public class CabsController : ApiController
    {
        public IHttpActionResult Get() => Ok(new { Message = $"Reached get method in {nameof(CabsController)}" });
    }
}
