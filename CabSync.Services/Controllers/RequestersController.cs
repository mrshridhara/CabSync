using CabSync.Data;
using CabSync.Data.Repositories;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    [RoutePrefix("api/requesters")]
    public class RequestersController : ApiController
    {
        private readonly IRepository<Requester> requestersRepository;

        public RequestersController()
        {
            requestersRepository = new RequestersRepository();
        }

        [Route]
        public IHttpActionResult Get() => Ok(requestersRepository.Read());

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

        [Route]
        public IHttpActionResult Post([FromBody]Requester requester)
        {
            var createdRequester = requestersRepository.Create(requester);
            return Created($"api/requesters/{createdRequester.UserId}", createdRequester);
        }

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