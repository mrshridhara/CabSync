﻿using CabSync.Data;
using CabSync.Data.Repositories;
using System.Linq;
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

        public IHttpActionResult GetByRegistrationNumber(string registrationNumber)
        {
            var matchingCab =
                cabRepository
                    .Read()
                    .FirstOrDefault(each => each.Equals(new Cab { RegistrationNumber = registrationNumber }));

            if (default(Cab).Equals(matchingCab))
                return NotFound();

            return Ok(matchingCab);
        }
    }
}