using CabSync.Data;
using CabSync.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    /// <summary>
    /// Provides methods to manipulate requesters data.
    /// </summary>
    [RoutePrefix("api/requesters")]
    public class RequestersController : ApiController
    {
        private readonly IRepository<Requester> requestersRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="RequestersController"/> class.
        /// </summary>
        public RequestersController()
        {
            requestersRepository = new RequestersRepository();
        }

        /// <summary>
        /// Gets all the available requesters.
        /// </summary>
        /// <returns>
        /// A sequence of available requesters.
        /// </returns>
        [Route]
        public IHttpActionResult Get() => Ok(requestersRepository.Read());

        /// <summary>
        /// Gets all the available requesters for the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>
        /// A sequence of available requesters.
        /// </returns>
        [Route("{userId}")]
        public IHttpActionResult GetByUserId(string userId)
        {
            var matchingRequester =
                requestersRepository
                    .Read()
                    .FirstOrDefault(each => each.UserId == userId);

            if (default(Requester).Equals(matchingRequester))
                return NotFound();

            return Ok(matchingRequester);
        }

        /// <summary>
        /// Accepts a new instance of <see cref="Requester"/> type which will be added.
        /// </summary>
        /// <param name="requester">A new instance of <see cref="Requester"/>.</param>
        /// <returns>
        /// A updated instance of <see cref="Requester"/> type.
        /// </returns>
        [Route]
        public IHttpActionResult Post([FromBody]Requester requester)
        {
            var createdRequester = requestersRepository.Create(requester);
            return Created($"api/requesters/{createdRequester.UserId}", createdRequester);
        }

        /// <summary>
        /// Accepts an updated instance of <see cref="Requester"/> type which will be added.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="requester">An updated instance of <see cref="Requester"/>.</param>
        /// <returns>
        /// Success status.
        /// </returns>
        [Route("{userId}")]
        public IHttpActionResult PutByUserId(string userId, [FromBody]Requester requester)
        {
            var matchingRequester =
                requestersRepository
                    .Read()
                    .FirstOrDefault(each => each.UserId == userId);

            if (default(Requester).Equals(matchingRequester))
                return NotFound();

            requestersRepository.Update(requester);
            return Ok();
        }
    }
}