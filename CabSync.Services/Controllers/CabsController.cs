using CabSync.Data;
using CabSync.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    [RoutePrefix("api/cabs")]
    public sealed class CabsController : ApiController
    {
        private readonly IRepository<Cab> cabRepository;

        public CabsController()
        {
            cabRepository = new CabsRepository();
        }

        [Route]
        public IHttpActionResult Get() => Ok(cabRepository.Read());

        [Route("{registrationNumber}")]
        public IHttpActionResult GetByRegistrationNumber(string registrationNumber)
        {
            var matchingCab =
                cabRepository
                    .Read()
                    .FirstOrDefault(each => each.RegistrationNumber == registrationNumber);

            if (default(Cab).Equals(matchingCab))
                return NotFound();

            return Ok(matchingCab);
        }
    }
}