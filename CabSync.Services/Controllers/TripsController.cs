using CabSync.Data;
using CabSync.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CabSync.Services.Controllers
{
    [RoutePrefix("api/trips")]
    public sealed class TripsController : ApiController
    {
        private readonly IRepository<Trip> tripRepository;

        public TripsController()
        {
            tripRepository = new TripsRepository();
        }

        [Route]
        public IHttpActionResult Get() => Ok(tripRepository.Read());

        [Route("{date}")]
        public IHttpActionResult GetByStartDate(string date)
        {
            var matchingTrip = FilterTripsByDate(date).FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        [Route("{date}/cabs/{registrationNumber}")]
        public IHttpActionResult GetByStartDateAndRegistrationNumber(string date, string registrationNumber)
        {
            var matchingTrip =
                FilterTripsByDate(date)
                    .Where(each => each.Cab.RegistrationNumber == registrationNumber)
                    .FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        [Route("{date}/users/{userId}")]
        public IHttpActionResult GetByStartDateAndRequesterUserId(string date, string userId)
        {
            var matchingTrip =
                FilterTripsByDate(date)
                    .Where(each => each.Requesters.Any(eachUser => eachUser.UserId == userId))
                    .FirstOrDefault();

            if (default(Trip).Equals(matchingTrip))
                return NotFound();

            return Ok(matchingTrip);
        }

        private static DateTime Parse(string dateTimeString)
        {
            if ("Today".Equals(dateTimeString, StringComparison.OrdinalIgnoreCase))
                return DateTime.Today;

            DateTime dateTime;
            DateTime.TryParse(dateTimeString, out dateTime);
            return dateTime;
        }

        private IEnumerable<Trip> FilterTripsByDate(string date)
                    => tripRepository
                        .Read()
                        .Where(each =>
                        {
                            var dateValue = Parse(date);

                            return
                                each.StartDateTime.GetValueOrDefault().Date == dateValue
                                || each.EndDateTime.GetValueOrDefault().Date == dateValue;
                        });
    }
}