using CabSync.Data;
using CabSync.Data.Repositories;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    public class CabsController : ApiController
    {
        private readonly IRepository<Cab> cabRepository;

        public CabsController()
        {
            cabRepository = new CabsRepository();
        }

        public IHttpActionResult Get() => Ok(cabRepository.Read());
    }
}