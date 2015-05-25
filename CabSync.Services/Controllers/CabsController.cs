using CabSync.Data;
using CabSync.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    /// <summary>
    /// Provides methods to manipulate cabs data.
    /// </summary>
    [RoutePrefix("api/cabs")]
    public sealed class CabsController : ApiController
    {
        private readonly IRepository<Cab> cabRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="CabsController"/> class.
        /// </summary>
        public CabsController()
        {
            cabRepository = new CabsRepository();
        }

        /// <summary>
        /// Gets all the available cabs.
        /// </summary>
        /// <returns>
        /// A sequence of available cabs.
        /// </returns>
        [Route]
        public IHttpActionResult Get() => Ok(cabRepository.Read());

        /// <summary>
        /// Gets all the available cabs for the specified <paramref name="registrationNumber"/>.
        /// </summary>
        /// <param name="registrationNumber">The cab registration number.</param>
        /// <returns>
        /// A sequence of available cabs.
        /// </returns>
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